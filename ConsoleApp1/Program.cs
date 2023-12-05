// See https://aka.ms/new-console-template for more information

using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

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
#endregion

var jesperAuthor =
    appDbContext.
        Authors.
        Include(a => a.BlogPosts).
        FirstOrDefault(a => a.Id == 1);

var blogPost1 = appDbContext.Blogs.Find(1);
var blogPost2 = appDbContext.Blogs.Find(2);

jesperAuthor.BlogPosts.Add(blogPost1);
jesperAuthor.BlogPosts.Add(blogPost2);

appDbContext.SaveChanges();

Console.WriteLine("appDbContext's changes saved!");