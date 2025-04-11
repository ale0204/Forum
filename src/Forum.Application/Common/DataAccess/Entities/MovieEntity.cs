using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities.Common;

namespace Forum.Application.Common.DataAccess.Entities;

public class MovieEntity : IStorageEntity, IAuditableEntity
{
    public Guid Id { get; init; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public float? Score { get; set; }
    public int? Duration { get; set; }
    public string? PosterUrl { get; set; }
    public DateOnly? LaunchDate { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedOnUtc { get; set; }
    public Guid UpdatedBy { get; set; }

}
