using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.Contracts.Requests;
using Forum.Application.Core.Movies.Commands.DeleteMovie;

namespace Forum.Application.Common.Mappings.Movies;

public static class DeleteMovieRequestMapping
{
    public static DeleteMovieCommand ToCommand(this DeleteMovieRequest request)
    {
        return new DeleteMovieCommand(
            request.Id
        );
    }
}
