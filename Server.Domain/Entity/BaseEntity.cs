namespace Server.Domain.Entity;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public DateTime DateDeleted { get; set; }
}
