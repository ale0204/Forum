using FastEndpoints;
using Forum.Application.Common.Contracts.Requests;
using Mediator;
using Microsoft.AspNetCore.Http;
using Forum.Presentation.Api.Common.Routes;
using System.Threading.Tasks;
using System.Threading;
using ErrorOr;
using Forum.Application.Common.Mappings.Movies;

namespace Forum.Presentation.Api.Core.Endpoints.Movies.DeleteMovie;

public class DeleteMovieEndpoint : Endpoint<DeleteMovieRequest, IResult>
{
    private readonly ISender _sender;

    public DeleteMovieEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Verbs(Http.DELETE);
        Routes(ApiRoutes.Movies.DELETE_MOVIE);
        Version(1);
        DontCatchExceptions();
    }

    public override async Task<IResult> ExecuteAsync(DeleteMovieRequest req, CancellationToken ct)
    {
        ErrorOr<Deleted> result = await _sender.Send(req.ToCommand(), ct);
        return result.Match(succes => TypedResults.Ok(succes), error => Results.BadRequest(error[0]));
    }
}
