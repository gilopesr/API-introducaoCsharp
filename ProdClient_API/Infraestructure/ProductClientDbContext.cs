using Microsoft.EntityFrameworkCore;
using ProdClient_API.Entities;

namespace ProdClient_API.Infraestructure
{
    public class ProductClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\gilop\\Downloads\\1737062251373-attachment.octet-stream");
        }
    }
}
