namespace Trailz.Core.Models;

public interface IEntity
{
}

public abstract class BaseEntity: IEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }
}