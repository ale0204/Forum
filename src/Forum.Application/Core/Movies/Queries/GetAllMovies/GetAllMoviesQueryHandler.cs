using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.Contracts.Responses;
using Forum.Application.Common.DataAccess.Entities;
using Forum.Application.Common.DataAccess.Repositories;
using Forum.Application.Common.DataAccess.UoW;
using Forum.Application.Common.Mappings.Movies;
using Mediator;

namespace Forum.Application.Core.Movies.Queries.GetAllMovies;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, ErrorOr<List<MovieResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<List<MovieResponse>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        IMovieRepository movieRepository = _unitOfWork.GetRepository<IMovieRepository>();

        ErrorOr<List<MovieEntity>> repositoryMoviesResult = await movieRepository.GetAllAsync(cancellationToken);

        if(repositoryMoviesResult.IsError) 
            return repositoryMoviesResult.Errors;
        return repositoryMoviesResult.Value.ToResponses();
    }
}
