// See https://aka.ms/new-console-template for more information

using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using DataAccess.Entities;

Console.WriteLine("Hello, World!");

using var appDbContext = new AppDbContext();

#region Utkommenterad-Kod
//appDbContext.Authors.Add(
//    new()
//    {
//        Name = "Jesper",
//    });
//appDbContext.Blogs.Add(
//    new()
//    {
//        Title = "ToadsEvents01",
//        Content = "Niklas har föreläst. Tjoho!"
//    });
//appDbContext.Blogs.Add(
//    new()
//    {
//        Title = "ToadsEvents02",
//        Content = "Niklas har livekodat. Tjoho!"
//    });

//var jesperAuthor =
//    appDbContext.
//        Authors.
//        Include(a => a.BlogPosts).
//        FirstOrDefault(a => a.Id == 1);

//var blogPost1 = appDbContext.Blogs.Find(1);
//var blogPost2 = appDbContext.Blogs.Find(2);

//jesperAuthor.BlogPosts.Add(blogPost1);
//jesperAuthor.BlogPosts.Add(blogPost2);

//appDbContext.SaveChanges();

//var testAuthor = new AuthorEntity();

//testAuthor.Name = "Anders";

//appDbContext.InsertInto(testAuthor);

//var blog = appDbContext.GetBlogById(1);
//Console.WriteLine(blog.ToString());

//var author = appDbContext.GetAuthorById(1);
//Console.WriteLine(author.ToString());

//var blog1 = appDbContext.GetBlogById(1);
//Console.WriteLine(blog1.ToString());

//appDbContext.UpdateBlogsById(1, "Toads0001", "Gustav har föreläst!");
//var blog2 = appDbContext.GetBlogById(1);
//Console.WriteLine(blog2.ToString());

//appDbContext.RemoveAuthorById(3);
//appDbContext.RemoveBlogById(2);

//var newComment = "En tredje kommentar";

//appDbContext.CommentBlogPostById(1, newComment);

//var comments = appDbContext.GetAllCommentsByBlogId(1);

//foreach (var comment in comments)
//{
//    Console.WriteLine(comment.CommentContent);
//}

#endregion







Console.WriteLine("Program.cs has finished!");