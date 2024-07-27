using Microsoft.EntityFrameworkCore;
using MinimalWebApi1.Core.Models;

namespace MinimalWebApi1.Core.DbContext;

public class SchoolContext : Microsoft.EntityFrameworkCore.DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

}