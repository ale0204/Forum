using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.Contracts.Responses;
using Forum.Application.Common.DataAccess.Entities;

namespace Forum.Application.Common.Mappings.Movies;

public static class MovieEntityMapping
{
    public static MovieResponse ToResponse(this MovieEntity entity)
    {
        return new MovieResponse(
            entity.Id,
            entity.Title,
            entity.Description,
            entity.Duration,
            entity.Score,
            entity.PosterUrl,
            entity.LaunchDate
        );
    }

    public static List<MovieResponse> ToResponses(this List<MovieEntity> entities)
    {
        return entities.ConvertAll(entity => ToResponse(entity));
    }
}
