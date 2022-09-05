using Microsoft.EntityFrameworkCore;
using Core;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
