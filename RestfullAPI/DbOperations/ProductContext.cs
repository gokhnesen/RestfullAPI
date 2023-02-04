using Microsoft.EntityFrameworkCore;
using RestfullAPI.Entities;


namespace RestfullAPI.DbOperations
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions options):base(options)
        {

        }

   
        
        public DbSet<Product> Products { get; set; }



 

    }
}
