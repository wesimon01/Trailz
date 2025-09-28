namespace Trailz.Core.Models;

public class Waypoint : BaseEntity
{
    public Guid Id { get; set; }
    public Guid TrailId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public Trail Trail { get; set; } = null!;

    
    public static class MaxLengths
    {
        public const int Name = 1000;
        public const int Description = 8000;
    }
}