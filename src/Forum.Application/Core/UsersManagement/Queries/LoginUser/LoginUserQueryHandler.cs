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

namespace Forum.Application.Core.UsersManagement.Queries.LoginUser;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, ErrorOr<LoginResponse>>

{
    private readonly IUnitOfWork _unitOfWork;

    public LoginUserQueryHandler(

        IUnitOfWork unitOfWork)

    {
        _unitOfWork = unitOfWork;
    }


    public async ValueTask<ErrorOr<LoginResponse>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {

        IUserRepository userRepository = _unitOfWork.GetRepository<IUserRepository>();

        ErrorOr<UserEntity?> getUserResult = await userRepository.GetByUsernameAsync(request.Username!, cancellationToken).ConfigureAwait(false);

        if (getUserResult.IsError)
            return getUserResult.Errors;
        else if (getUserResult.Value is null)
            return Errors.Authentication.InvalidUsernameOrPassword;

        if(getUserResult.Value.Password != request.Password)
            return Errors.Authentication.InvalidUsernameOrPassword;

        return new LoginResponse(getUserResult.Value.Id, getUserResult.Value.Username, Guid.NewGuid().ToString());
    }

}
