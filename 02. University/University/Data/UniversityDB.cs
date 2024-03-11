using Microsoft.EntityFrameworkCore;
using University.Model;

namespace University.Data
{
    public class UniversityDB : DbContext
    {
        public UniversityDB(DbContextOptions<UniversityDB> options) : base(options)
        {
        }

        public DbSet<Student> Student {  get; set; } = null!;
        public DbSet<Class> Class { get; set; } = null!;
    }

}
