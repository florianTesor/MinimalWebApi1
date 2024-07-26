using Microsoft.EntityFrameworkCore;
using MinimalWebApi1.DbContext.Models;

namespace MinimalWebApi1.DbContext;

public class SchoolContext : Microsoft.EntityFrameworkCore.DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

}