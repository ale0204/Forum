using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Application.Common.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.Common.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasColumnOrder(0);

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnOrder(1);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnOrder(2);

        // audit
        builder.Property(x => x.CreatedOnUtc)
             .IsRequired()
             .HasColumnOrder(3);

        builder.Property(x => x.CreatedBy)
             .IsRequired()
             .HasColumnOrder(4);

        builder.Property(x => x.UpdatedOnUtc)
             .HasDefaultValue(null)
             .HasColumnOrder(5);

        builder.Property(x => x.UpdatedBy)
             .HasDefaultValue(null)
             .HasColumnOrder(6);
    }
}

