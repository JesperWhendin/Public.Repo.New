using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace DataAccess.Entities;

public class CommentEntity : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required] public string CommentContent { get; set; } = string.Empty;


}