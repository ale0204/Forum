﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Forum.Domain.Common.Errors;
public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidUsernameOrPassword => Error.Failure(description: "Invalid username or password!");
    }
}
