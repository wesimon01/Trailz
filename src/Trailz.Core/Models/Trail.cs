namespace Trailz.Core.Models;

public class Trail : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal LengthMiles { get; set; }
    public DifficultyLevel? Difficulty { get; set; } 
    public decimal ElevationGainFeet { get; set; }
    public bool IsLoop { get; set; }

    public ICollection<Review> Reviews { get; set; } = [];
    public ICollection<TrailPhoto> TrailPhotos { get; set; } = [];
    public ICollection<Waypoint> Waypoints { get; set; } = [];

    public static class MaxLengths
    {
        public const int Name = 500;
        public const int Description = 2000;
        public const int LengthMiles = 2000;
        public const int Difficulty = 20;
    }
}

public enum DifficultyLevel
{
    Easy, 
    Medium, 
    Hard
}

