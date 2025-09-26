using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trailz.Core.Models;

namespace Trailz.Infrastructure.Database.EntityConfigurations;

internal class WaypointConfiguration : IEntityTypeConfiguration<Waypoint>
{
    public void Configure(EntityTypeBuilder<Waypoint> builder)
    {
        builder.ToTable("Waypoints");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Name)
            .HasMaxLength(Waypoint.MaxLengths.Name)
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasMaxLength(Waypoint.MaxLengths.Description)
            .IsRequired();
        
        builder.HasOne(e => e.Trail)
            .WithMany(e => e.Waypoints)
            .HasForeignKey(e => e.TrailId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}