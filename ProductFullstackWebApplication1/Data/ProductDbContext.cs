using Microsoft.EntityFrameworkCore;
using ProductFullstackWebApplication1.Model;

namespace ProductFullstackWebApplication1.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options):base(options)
        {
            
        }

       public DbSet<Product> ProductTBL { get; set; }
    }
}
