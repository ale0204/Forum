﻿using System;
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

namespace Forum.Application.Core.Movies.Commands.AddMovie;

public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, ErrorOr<MovieResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async ValueTask<ErrorOr<MovieResponse>> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        IMovieRepository movieRepository = _unitOfWork.GetRepository<IMovieRepository>();

        MovieEntity repositoryEntity = request.ToRepositoryEntity();

        await movieRepository.InsertAsync(repositoryEntity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        ErrorOr<MovieEntity?> repositoryMovieResult = await movieRepository.GetByIdAsync(repositoryEntity.Id, cancellationToken);
        if (repositoryMovieResult.IsError)
            return repositoryMovieResult.Errors;
        return repositoryMovieResult.Value!.ToResponse();
    }
}
