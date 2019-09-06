using Microsoft.EntityFrameworkCore;

namespace EFAssignment.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {}
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<DepartmentDetails> DepartmentDetails { get; set; }
    }
}
