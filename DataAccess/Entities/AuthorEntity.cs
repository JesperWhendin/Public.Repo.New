using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class AuthorEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public List<BlogEntity> BlogPosts { get; set; } = new();
}