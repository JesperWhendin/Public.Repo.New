using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class BlogEntity : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    public List<CommentEntity> Comments { get; set; } = new();

    public override string ToString()
    {
        var blogToString = string.Empty;
        blogToString += $"Id: {Id}\nTitle: {Title}\nContent: {Content}";
        return blogToString;
    }
}
