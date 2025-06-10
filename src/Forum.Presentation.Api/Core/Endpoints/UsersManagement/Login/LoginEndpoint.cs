using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Forum.Application.Common.Contracts.Requests;
using Forum.Application.Common.Contracts.Responses;
using Forum.Presentation.Api.Common.Routes;
using Forum.Application.Common.Mappings.Movies;
using Mediator;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Forum.Application.Common.Mappings.Authentication;



namespace Forum.Presentation.Api.Core.Endpoints.UsersManagement.Login;

public class LoginEndpoint : Endpoint<LoginRequest, IResult>
{
    private readonly ISender _sender;

    public LoginEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Verbs(Http.POST);
        Routes(ApiRoutes.Authentication.LOGIN);
        Version(1);
        DontCatchExceptions();
    }

    public override async Task<IResult> ExecuteAsync(LoginRequest request, CancellationToken ct)
    {
        ErrorOr<LoginResponse> result = await _sender.Send(request.ToCommand(), ct);
        return result.Match(success => TypedResults.Ok(success), error => Results.BadRequest(error[0]));
    }
}
