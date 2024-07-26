using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
//Contains the DbContext, repositories,
//and implementations of service interfaces defined in the Application layer.
public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

}