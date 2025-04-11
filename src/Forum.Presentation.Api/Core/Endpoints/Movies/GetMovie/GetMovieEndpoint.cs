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


namespace Forum.Presentation.Api.Core.Endpoints.Movies.GetMovie;

public class GetMovieEndpoint : Endpoint<GetMovieRequest, IResult>
{
    private readonly ISender _sender;
    public GetMovieEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Verbs(Http.GET);
        Routes(ApiRoutes.Movies.GET_MOVIE);
        Version(1);
        DontCatchExceptions();
    }
    public override async Task<IResult> ExecuteAsync(GetMovieRequest req, CancellationToken ct)
    {
        ErrorOr<MovieResponse> result = await _sender.Send(req.ToQuery(), ct);
        return result.Match(succes => TypedResults.Ok(succes), error => Results.BadRequest(error[0]));
    }
}
