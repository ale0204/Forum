using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.Contracts.Requests;
using Forum.Application.Core.Movies.Queries.GetMovie;

namespace Forum.Application.Common.Mappings.Movies;

public static class GetMovieRequestMapping
{
    public static GetMovieQuery ToQuery(this GetMovieRequest request)
    {
        return new GetMovieQuery(
            request.Id
        );
    }
}
