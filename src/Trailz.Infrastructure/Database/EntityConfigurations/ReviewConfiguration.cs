using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trailz.Core.Models;

namespace Trailz.Infrastructure.Database.EntityConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Comments)
            .HasMaxLength(Review.MaxLengths.Comments)
            .IsRequired();

        builder.HasOne(e => e.Trail)
            .WithMany(e => e.Reviews)
            .HasForeignKey(e => e.TrailId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}