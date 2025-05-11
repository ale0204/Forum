
namespace Forum.Presentation.Web.Common.Api
{
    public interface IApiHttpClient
    {
        Task<TResponse> GetAsync<TResponse>(string endPoint, CancellationToken cancellationToken = default);
        Task DeleteAsync(string endPoint, CancellationToken cancellationToken = default);
        Task<TResponse> PutAsync<TResponse, TModel>(string endPoint, TModel data, CancellationToken cancellationToken = default);
        Task<TResponse> PostAsync<TResponse, TModel>(string endPoint, TModel data, CancellationToken cancellationToken = default);
    }
}