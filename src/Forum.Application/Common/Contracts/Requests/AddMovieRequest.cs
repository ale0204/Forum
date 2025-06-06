﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Common.Contracts.Requests;

/// <summary>
/// Represents a request to add a movie
/// </summary>
/// <param name="Title">The title of the movie to add.</param>
/// <param name="Duration">The optional duration in total minutes of the movie.</param>
/// <param name="Score">The optional score of the movie.</param>
/// <param name="PosterUrl">The optional poster of the movie expressed as internet URL.</param>
/// <param name="LaunchDate">The optional date when the movie was launched.</param>
public record AddMovieRequest(
    string Title, 
    string? Description,
    int? Duration,
    float? Score,
    string? PosterUrl,
    DateOnly? LaunchDate
);