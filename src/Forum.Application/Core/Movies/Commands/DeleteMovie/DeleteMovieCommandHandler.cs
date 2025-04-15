using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using Forum.Application.Common.DataAccess.Repositories;
using Forum.Application.Common.DataAccess.UoW;
using Mediator;

namespace Forum.Application.Core.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, ErrorOr<Deleted>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<ErrorOr<Deleted>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        IMovieRepository movieRepository = _unitOfWork.GetRepository<IMovieRepository>();

        ErrorOr<Deleted> repositoryDeleteResult = await movieRepository.DeleteByIdAsync(request.Id, cancellationToken);
        if(repositoryDeleteResult.IsError) 
            return repositoryDeleteResult.Errors;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Deleted;
    }
}
