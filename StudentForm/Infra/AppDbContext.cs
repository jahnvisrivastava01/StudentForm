using Microsoft.EntityFrameworkCore;
using StudentForm.Models;

namespace StudentForm.Infra
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
