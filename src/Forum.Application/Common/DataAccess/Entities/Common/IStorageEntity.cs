using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Common.DataAccess.Entities.Common;

public interface IStorageEntity
{
    Guid Id { get; init; }
}
