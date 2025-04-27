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

namespace Forum.Application.Core.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, ErrorOr<MovieResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<MovieResponse>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        IMovieRepository movieRepository = _unitOfWork.GetRepository<IMovieRepository>();

        MovieEntity repositoryEntity = request.ToRepositoryEntity();

        ErrorOr<Updated> repositoryUpdateMovieResult = await movieRepository.UpdateAsync(repositoryEntity, cancellationToken);
        if (repositoryUpdateMovieResult.IsError)
            return repositoryUpdateMovieResult.Errors;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        ErrorOr<MovieEntity?> repositoryGetMovieResult = await movieRepository.GetByIdAsync(repositoryEntity.Id, cancellationToken);
        if (repositoryGetMovieResult.IsError)
            return repositoryGetMovieResult.Errors;
        return repositoryGetMovieResult.Value!.ToResponse();
    }
}
