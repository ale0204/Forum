using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Forum.Domain.Common.Errors;
public static partial class Errors
{
    public static class Users
    {
        public static Error UserAlreadyExists => Error.Conflict(description: "User already exists!");
        public static Error UserDoesNotExist => Error.NotFound(description: "User does not exist!");
    }
}
