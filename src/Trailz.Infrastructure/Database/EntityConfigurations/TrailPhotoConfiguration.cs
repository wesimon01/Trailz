using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trailz.Core.Models;

namespace Trailz.Infrastructure.Database.EntityConfigurations;

public class TrailPhotoConfiguration : IEntityTypeConfiguration<TrailPhoto>
{
    public void Configure(EntityTypeBuilder<TrailPhoto> builder)
    {
        builder.ToTable("TrailPhotos");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Caption)
            .HasMaxLength(TrailPhoto.MaxLengths.Caption)
            .IsRequired();

        builder.HasOne(e => e.Trail)
            .WithMany(e => e.TrailPhotos)
            .HasForeignKey(e => e.TrailId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}