using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.Common.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<MovieEntity>
{
    public void Configure(EntityTypeBuilder<MovieEntity> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasColumnOrder(0);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnOrder(1);

        builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .HasColumnOrder(2);

        builder.Property(x => x.Score)
           .HasColumnOrder(3);

        builder.Property(x => x.PosterUrl)
            .HasMaxLength(255)
            .HasColumnOrder(4);

        builder.Property(x => x.LaunchDate)
            .HasColumnOrder(5);

        // audit
        builder.Property(x => x.CreatedOnUtc)
             .IsRequired()
             .HasColumnOrder(6);

        builder.Property(x => x.CreatedBy)
             .IsRequired()
             .HasColumnOrder(7);

        builder.Property(x => x.UpdatedOnUtc)
             .HasDefaultValue(null)
             .HasColumnOrder(8);

        builder.Property(x => x.UpdatedBy)
             .HasDefaultValue(null)
             .HasColumnOrder(9);
    }
}
