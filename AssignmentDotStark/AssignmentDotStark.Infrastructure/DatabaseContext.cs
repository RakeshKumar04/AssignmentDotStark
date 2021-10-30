using AssignmentDotStark.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AssignmentDotStark.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Products> Products { get; set; }
    }
}
