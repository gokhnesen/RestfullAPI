using Microsoft.EntityFrameworkCore;
using RestfullAPI.Entities;

namespace RestfullAPI.DbOperations.DataSeed
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context= new ProductContext(serviceProvider.GetRequiredService<DbContextOptions<ProductContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }
                context.Products.AddRange(
                new Product()
                {
                    Id = 1,
                    Name="iPhone 14",
                    Description="Phone".ToLower(),
                    Price=20000,

                },
                new Product()
                {
                    Id = 2,
                    Name = "Samsung S22",
                    Description = "Phone".ToLower(),
                    Price = 10000,

                },
                new Product()
                {
                   Id = 3,
                   Name = "Asus ROG",
                   Description = "Laptop".ToLower(),
                   Price = 25000,

                }


                );
                context.SaveChanges();
            }
        }
    }
}
