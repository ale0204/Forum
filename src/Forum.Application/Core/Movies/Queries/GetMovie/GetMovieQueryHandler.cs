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

namespace Forum.Application.Core.Movies.Queries.GetMovie;

public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, ErrorOr<MovieResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMovieQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async ValueTask<ErrorOr<MovieResponse>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        IMovieRepository movieRepository = _unitOfWork.GetRepository<IMovieRepository>();

        ErrorOr<MovieEntity?> repositoryMovieResult = await movieRepository.GetByIdAsync(request.Id, cancellationToken);
        if (repositoryMovieResult.IsError)
            return repositoryMovieResult.Errors;
        return repositoryMovieResult.Value!.ToResponse();
    }
}
