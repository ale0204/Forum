using System;
using FastEndpoints;
using Forum.Application.Common.Contracts.Requests;
using Forum.Application.Common.Contracts.Responses;

namespace Forum.Presentation.Api.Core.Endpoints.Movies.AddMovie;

public class AddMovieEndpointSummary : Summary<AddMovieEndpoint, AddMovieRequest>
{
    public AddMovieEndpointSummary()
    {
        Summary = "Adds a new movie";
        Description = "Creates a new movie and returns in details ";
        ExampleRequest = new AddMovieRequest(
            Title: "Flaw",
            Description: "Movie about a cat",
            Duration: 121,
            Score: 4.5f,
            PosterUrl: "C:MyMovie.jpg",
            DateOnly.FromDateTime(DateTime.Now)
        );
        RequestParam(movie => movie.Title, "The title of the movie to add.");
        RequestParam(movie => movie.Duration, "The optional duration in total minutes of the movie.");
        RequestParam(movie => movie.Score, "The optional score of the movie.");
        RequestParam(movie => movie.PosterUrl, "The optional poster of the movie expressed as internet URL.");
        RequestParam(movie => movie.LaunchDate, "The optional date when the movie was launched.");

        ResponseParam<MovieResponse>(movie => movie.Id, "The unique identifier of the movie");
        Response(200, "The movie was created", example:
            new MovieResponse(
                Id: Guid.NewGuid(),
                Title: "Flaw",
                Description: "Movie about a cat",
                Duration: 121,
                Score: 4.5f,
                PosterUrl: "C:MyMovie.jpg",
                DateOnly.FromDateTime(DateTime.Now)
            ));
        Response(403, "The request did not pass validation checks");




    }
}
