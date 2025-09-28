using Bogus;
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

        var faker = new Faker<Trail>()
            .RuleFor(x => x.Name, f => f.Name.FullName())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            .RuleFor(x => x.LengthMiles, f => f.Random.Decimal(0, 50))
            .RuleFor(x => x.Difficulty, f => f.Random.Enum<DifficultyLevel>())
            .RuleFor(x => x.ElevationGainFeet,f => f.Random.Decimal(0, 5000))
            .RuleFor(x => x.IsLoop, f => f.Random.Bool());

        builder.HasData(faker.Generate(50));
    }
}