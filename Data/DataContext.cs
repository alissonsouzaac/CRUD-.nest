using Microsoft.EntityFrameworkCore;
using testeA.Models;

namespace testeA.Data {


    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
            {
            }

            public DbSet<Product> Products { get; set; }

            public DbSet<Category> Category { get; set; }
    }
}