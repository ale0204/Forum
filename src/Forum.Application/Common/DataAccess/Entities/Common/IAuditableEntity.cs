using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Common.DataAccess.Entities.Common;

public interface IAuditableEntity
{
    DateTime CreatedOnUtc { get; set; }
    Guid CreatedBy { get; set; }
    DateTime UpdatedOnUtc { get; set; }
    Guid UpdatedBy { get; set; }
}
