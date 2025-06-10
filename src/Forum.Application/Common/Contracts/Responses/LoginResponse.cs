using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Common.Contracts.Responses;

public record LoginResponse(
    Guid Id,
    string Username,
    string Token
);