using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Common.Contracts.Requests;

public record UpdateMovieRequest(
    Guid Id,
    string Title,
    string? Description,
    int? Duration,
    float? Score,
    string? PosterUrl,
    DateOnly? LaunchDate
);
