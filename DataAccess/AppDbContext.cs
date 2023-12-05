using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System;

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
}