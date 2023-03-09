using Microsoft.EntityFrameworkCore;

namespace EmployeeExample.Models
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options) {
        
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("TrustServerCertificate=True;Server=LAPTOP-MTJR9ITS\\SQLEXPRESS;Database=EmployeeManagement;Trusted_Connection=True");
        }
    }
}
