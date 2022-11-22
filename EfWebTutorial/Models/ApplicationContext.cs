using Microsoft.EntityFrameworkCore;

namespace EfWebTutorial.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Group> Groups { get; set; } 

        public DbSet <Faculty> Faculties { get; set; }

        public DbSet <Subject> Subjects { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
