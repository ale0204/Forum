using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Forum.Presentation.Web.Common.Api;

public class ApiHttpClient : IApiHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly HttpContext? _httpContext;
    private readonly JsonSerializerOptions _serializerOptions;

    public ApiHttpClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContext = httpContextAccessor.HttpContext;
        _httpClient.BaseAddress = new Uri("http://localhost:5289/api/v1/");
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() }
        };
    }

    public async Task<TResponse> GetAsync<TResponse>(string endPoint, CancellationToken cancellationToken = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, endPoint);
        AuthenticationHeaderValue? authenticationHeader = GetAuthenticationHeader();
        if (authenticationHeader is not null)
            request.Headers.Authorization = authenticationHeader;
        return await SendRequestAsync<TResponse>(request, cancellationToken);
    }

    public async Task DeleteAsync(string endPoint, CancellationToken cancellationToken = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Delete, endPoint);
        AuthenticationHeaderValue? authenticationHeader = GetAuthenticationHeader();
        if (authenticationHeader is not null)
            request.Headers.Authorization = authenticationHeader;
        HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
        string content = await response.Content.ReadAsStringAsync(cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.StatusCode.ToString());
        }
    }
    public async Task<TResponse> PutAsync<TResponse, TModel>(string endPoint, TModel data, CancellationToken cancellationToken = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Put, endPoint);
        AuthenticationHeaderValue? authenticationHeader = GetAuthenticationHeader();
        if (authenticationHeader is not null)
            request.Headers.Authorization = authenticationHeader;
        request.Content = new StringContent(JsonSerializer.Serialize(data, _serializerOptions), Encoding.UTF8, "application/json");
        return await SendRequestAsync<TResponse>(request, cancellationToken);
    }

    public async Task<TResponse> PostAsync<TResponse, TModel>(string endPoint, TModel data, CancellationToken cancellationToken = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, endPoint);
        AuthenticationHeaderValue? authenticationHeader = GetAuthenticationHeader();
        if (authenticationHeader is not null)
            request.Headers.Authorization = authenticationHeader;
        request.Content = new StringContent(JsonSerializer.Serialize(data, _serializerOptions), Encoding.UTF8, "application/json");
        return await SendRequestAsync<TResponse>(request, cancellationToken);
    }

    private async Task<TResponse> SendRequestAsync<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
        string content = await response.Content.ReadAsStringAsync(cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            if (string.IsNullOrEmpty(content))
                return default!;
            return JsonSerializer.Deserialize<TResponse>(content, _serializerOptions)!;
        }
        else
        {
            throw new Exception(content);
        }
    }

    private AuthenticationHeaderValue? GetAuthenticationHeader()
    {
        string? token = _httpContext?.User?.FindFirst("Token")?.Value;
        return !string.IsNullOrEmpty(token) ? new AuthenticationHeaderValue("Bearer", token) : null;
    }
}
