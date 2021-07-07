using CheckRepair.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckRepair.Repositories.Implimentations
{
    public class ApplicationContext : DbContext
    {
        DbSet<Device> Devices { get; set; }
        DbSet<Report> Docs { get; set; }
        DbSet<Worker> Workers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {
            Database.EnsureCreated();
        }
    }
}