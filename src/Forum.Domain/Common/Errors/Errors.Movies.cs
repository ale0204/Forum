using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Forum.Domain.Common.Errors;
public static partial class Errors
{
    public static class Movies
    {
        public static Error MovieAlreadyExists => Error.Conflict(description: "Movie already exists!");
    }
}
