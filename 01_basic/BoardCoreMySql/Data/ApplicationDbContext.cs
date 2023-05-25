using BoardCoreMySql.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardCoreMySql.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }

}
