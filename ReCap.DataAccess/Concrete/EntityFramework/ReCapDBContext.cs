using Microsoft.EntityFrameworkCore;
using ReCap.Entities.Concrete;

namespace ReCap.DataAccess.Concrete.EntityFramework
{
    public class ReCapDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server= (localdb)\MSSQLLocalDB; Database=ReCapDB; Trusted_Connection = true;");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
