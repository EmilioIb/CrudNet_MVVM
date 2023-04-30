using CrudNet_MVVM.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudNet_MVVM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Dog> Dog { get; set; }
    }
}
