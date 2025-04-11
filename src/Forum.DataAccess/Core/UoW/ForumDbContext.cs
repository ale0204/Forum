using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum.DataAccess.Core.UoW;

/// <remarks>To add a new migration: add-migration InitialMigration -p Forum.DataAccess -s Forum.Presentation.Api -o Common\Migrations</remarks>
/// <remarks>To update the database: update-database -p Forum.DataAccess -s Forum.Presentation.Api</remarks>
public class ForumDbContext : DbContext
{
    public virtual DbSet<MovieEntity> Movies { get; set; }

    public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ForumDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
