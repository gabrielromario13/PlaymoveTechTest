namespace PlaymoveTechTest.Domain.Model;

public abstract class BaseEntity
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id { get; protected set; }
    public virtual DateTime CreatedAt { get; protected set; } = DateTime.Now;
    public virtual DateTime UpdatedAt { get; protected set; } = DateTime.Now;
}