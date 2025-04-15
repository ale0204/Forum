using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ErrorOr;

namespace Forum.Application.Common.DataAccess.Repositories.Common.Actions;

public interface IDeleteByIdRepositoryAction 
{
    Task<ErrorOr<Deleted>> DeleteByIdAsync(Guid id, CancellationToken token);
}
