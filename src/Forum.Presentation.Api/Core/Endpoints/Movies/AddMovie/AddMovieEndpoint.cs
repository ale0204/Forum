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

namespace Forum.Presentation.Api.Core.Endpoints.Movies.AddMovie;

public class AddMovieEndpoint : Endpoint<AddMovieRequest, IResult>
{
    private readonly ISender _sender;

    public AddMovieEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        AllowAnonymous(); // permite accesul fara autentificare
        Verbs(Http.POST);
        Routes(ApiRoutes.Movies.ADD_MOVIE);
        Version(1);
        DontCatchExceptions();
    }

    public override async Task<IResult> ExecuteAsync(AddMovieRequest request, CancellationToken ct)
    {
        ErrorOr<MovieResponse> result = await _sender.Send(request.ToCommand(), ct);
        // foloseste pachetul Mediator pentru a ruta comenzile si interogarile catre handlerii corespunzatori
        return result.Match(success => TypedResults.Ok(success), error => Results.BadRequest(error[0]));
        //if (result.IsError)
        //    return Results.BadRequest(result.FirstError);
        //else
        //    return Results.Ok(result.Value);
    }
}
