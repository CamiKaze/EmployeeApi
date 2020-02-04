using Microsoft.EntityFrameworkCore;

namespace Employees.API.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
    }
}