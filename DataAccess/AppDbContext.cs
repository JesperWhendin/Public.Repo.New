using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System;
using System.Collections.Generic;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<BlogEntity> Blogs { get; set; } = null!;
    public DbSet<AuthorEntity> Authors { get; set; } = null!;
    public DbSet<CommentEntity> Comments { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = DESKTOP-8EBV68R; Initial Catalog = EFC-CodeFirst1-5; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
    }

    public void InsertInto(IEntity entity)
    {
        if (!(entity is null))
        {
            if (entity is BlogEntity)
            {
                Blogs.Add(entity as BlogEntity);
            }
            if (entity is AuthorEntity)
            {
                Authors.Add(entity as AuthorEntity);
            }
            if (entity is CommentEntity)
            {
                Comments.Add(entity as CommentEntity);
            }
            SaveChanges();
        }
    }

    // GetBlogById & GetAuthorById fungerar likadant.
    // Author är skriven som en one-liner för att demonstrera
    // ett annat sätt att åstadkomma samma sak.

    public BlogEntity GetBlogById(int id)
    {
        var blog = Blogs.FirstOrDefault(b => b.Id == id);

        return blog;
    }
    public AuthorEntity GetAuthorById(int id) =>
        Authors
            .Include(b => b.BlogPosts)
            .FirstOrDefault(a => a.Id == id);


    public void UpdateAuthorById(int id, string newName)
    {
        var author = GetAuthorById(id);
        author.Name = newName;
        SaveChanges();
    }

    public void UpdateBlogsById(int id, string? newTitle, string? newContent)
    {
        var blog = GetBlogById(id);

        if (!(blog is null))
        {
            if (newTitle != blog.Title && newTitle is not null)
            {
                blog.Title = newTitle;
            }
            if (newContent != blog.Content && newContent is not null)
            {
                blog.Content = newContent;
            }
        }

        SaveChanges();
    }

    public void RemoveAuthorById(int id)
    {
        var author = Authors.FirstOrDefault(a => a.Id == id);
        Console.WriteLine($"{author.Name} has been removed.");
        Remove(author);
        SaveChanges();
    }

    public void RemoveBlogById(int id)
    {
        var blog = Blogs.FirstOrDefault(b => b.Id == id);
        Console.WriteLine($"{blog.Title} has been removed.");
        Remove(blog);
        SaveChanges();
    }

    public void CommentBlogPostById(int id, string comment)
    {
        var blog = GetBlogById(id);
        if (blog != null)
        {
            var newComment = new CommentEntity();
            newComment.CommentContent = comment;
            blog.Comments.Add(newComment);
            SaveChanges();
            return;
        }
        Console.WriteLine($"Blogpost with id {id} not found.");
    }

    public List<CommentEntity>? GetAllCommentsByBlogId(int id)
    {
        BlogEntity? blog = Blogs
            .Include(c => c.Comments)
            .FirstOrDefault(b => b.Id == id);
        List<CommentEntity> comments = new List<CommentEntity>();

        if (blog != null)
        {
            comments.AddRange(blog.Comments);
        }
        return comments;
    }

}