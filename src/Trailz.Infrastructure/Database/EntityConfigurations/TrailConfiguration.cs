using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trailz.Core.Models;

namespace Trailz.Infrastructure.Database.EntityConfigurations;

class TrailConfiguration : IEntityTypeConfiguration<Trail>
{
    public void Configure(EntityTypeBuilder<Trail> builder)
    {
        builder.ToTable("Trails");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Name)
            .HasMaxLength(Trail.MaxLengths.Name)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(Trail.MaxLengths.Description)
            .IsRequired();

        builder.Property(e => e.LengthMiles)
            .HasMaxLength(Trail.MaxLengths.LengthMiles);

        builder.Property(e => e.Difficulty)
            .HasMaxLength(Trail.MaxLengths.Difficulty)
            .HasConversion<string>();
    }
}