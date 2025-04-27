using FastEndpoints;
using Forum.Application.Common.Contracts.Requests;
using Mediator;
using Microsoft.AspNetCore.Http;
using Forum.Presentation.Api.Common.Routes;
using System.Threading.Tasks;
using System.Threading;
using ErrorOr;
using Forum.Application.Common.Contracts.Responses;
using Forum.Application.Common.Mappings.Movies;

namespace Forum.Presentation.Api.Core.Endpoints.Movies.UpdateMovie;

public class UpdateMovieEndpoint : Endpoint<UpdateMovieRequest, IResult>
{
    private readonly ISender _sender;

    public UpdateMovieEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Verbs(Http.PUT);
        Routes(ApiRoutes.Movies.UPDATE_MOVIE);
        Version(1);
        DontCatchExceptions();
    }

    public override async Task<IResult> ExecuteAsync(UpdateMovieRequest req, CancellationToken ct)
    {
        ErrorOr<MovieResponse> result = await _sender.Send(req.ToCommand(), ct);
        return result.Match(success => TypedResults.Ok(success), error => Results.BadRequest(error[0]));
    }
}
