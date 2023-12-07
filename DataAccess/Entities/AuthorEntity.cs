using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class AuthorEntity : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public List<BlogEntity> BlogPosts { get; set; } = new();

    public override string ToString()
    {
        var authorToString = string.Empty;
        authorToString += $"Id: {Id}\nTitle: {Name}";
        foreach (var posts in BlogPosts)
        {
            authorToString += $"\n{posts.Title}";
        }
        return authorToString;
    }
}