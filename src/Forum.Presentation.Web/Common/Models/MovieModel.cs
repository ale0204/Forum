namespace Forum.Presentation.Web.Common.Models;

public record MovieModel(
    Guid? Id,
    string? Title,
    string? Description,
    int? Duration,
    float? Score,
    string? PosterUrl,
    DateOnly? LaunchDate
);


