using FastEndpoints;
using Mediator;
using Microsoft.AspNetCore.Http;
using Forum.Presentation.Api.Common.Routes;
using System.Threading.Tasks;
using System.Threading;
using ErrorOr;
using Forum.Application.Common.Contracts.Responses;
using System.Collections.Generic;
using Forum.Application.Core.Movies.Queries.GetAllMovies;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;

namespace Forum.Presentation.Api.Core.Endpoints.Movies.GetAllMovies;

public class GetAllMoviesEndpoint : Endpoint<EmptyRequest, IResult>
{
    private readonly ISender _sender;

    public GetAllMoviesEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        AllowAnonymous();
        Verbs(Http.GET);
        Routes(ApiRoutes.Movies.GET_MOVIES);
        Version(1);
        DontCatchExceptions();
    }

    public override async Task<IResult> ExecuteAsync(EmptyRequest req, CancellationToken ct)
    {
        ErrorOr<List<MovieResponse>> result = await _sender.Send(new GetAllMoviesQuery(), ct);
        return result.Match(succes => TypedResults.Ok(succes), errors => Results.BadRequest(errors[0].Description));
    }
}
