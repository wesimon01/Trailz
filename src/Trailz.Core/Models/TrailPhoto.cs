namespace Trailz.Core.Models;

public class TrailPhoto : BaseEntity
{
    public Guid Id { get; set; }
    public Guid TrailId { get; set; }
    public byte[] Image { get; set; } = null!;
    public string? Caption { get; set; }

    public Trail Trail { get; set; } = null!;

    public static class MaxLengths
    {
        public const int Caption = 1000;
    }
}