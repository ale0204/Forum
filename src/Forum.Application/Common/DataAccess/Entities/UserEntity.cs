using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities.Common;

namespace Forum.Application.Common.DataAccess.Entities;

public class UserEntity : IStorageEntity, IAuditableEntity
{
    public Guid Id { get; init; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
    public Guid UpdatedBy { get; set; }
}
