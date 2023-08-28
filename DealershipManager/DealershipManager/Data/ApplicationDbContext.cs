using DealershipManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DealershipManager.Data
{
    // ApplicationDbContext = Abstractizare asupra bazei de date
    public class ApplicationDbContext : DbContext
    {
        // Abstractizare a tabelului CARS din baza de date
        public DbSet<Car> Cars { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
