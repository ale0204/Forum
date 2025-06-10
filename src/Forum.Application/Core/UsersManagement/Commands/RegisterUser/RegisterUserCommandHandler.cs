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
using Mediator;
using Forum.Domain.Common.Errors;
using Forum.Application.Common.Mappings.Authentication;

namespace Forum.Application.Core.UsersManagement.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<RegistrationResponse>>

{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(

        IUnitOfWork unitOfWork)

    {
        _unitOfWork = unitOfWork;
    }


    public async ValueTask<ErrorOr<RegistrationResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // check if any users already exists (admin account is only set once!)

        IUserRepository userRepository = _unitOfWork.GetRepository<IUserRepository>();

        ErrorOr<UserEntity?> getUserResult = await userRepository.GetByUsernameAsync(request.Username!, cancellationToken).ConfigureAwait(false);

        if (getUserResult.IsError)
            return getUserResult.Errors;
        else if (getUserResult.Value is not null)
            return Errors.Users.UserAlreadyExists;

        UserEntity user = request.ToRepositoryEntity();

        // insert the user
        ErrorOr<Created> insertUserResult = await userRepository.InsertAsync(user, cancellationToken).ConfigureAwait(false);
        if (insertUserResult.IsError)
            return insertUserResult.Errors;
        await _unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return new RegistrationResponse(user.Id, user.Username);

    }

}


