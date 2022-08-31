using EmployeeAJAXCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAJAXCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Basic> basics { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }
    }
}
