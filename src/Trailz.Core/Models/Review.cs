namespace Trailz.Core.Models;

public class Review
{
    public Guid Id { get; set; } 
    public Guid TrailId { get; set; }
    public string UserId { get; set; } = null!;
    public int Rating { get; set; }
    public string Comments { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; }
    public Trail Trail { get; set; } = null!;
    public User User { get; set; } = null!;
    
    public static class MaxLengths
    {
        public const int Comments = 10000;
    }
}