using CampusHub.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CampusHub.Shared.Entities;


namespace CampusHub.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyCategory> PropertyCategories { get; set; }

        public DbSet<PropertyImage> PropertyImages { get; set; }    

        public DbSet<UniversityLife> UniversityLives { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<State>().HasIndex("CountryId", "Name").IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
        }


    }

}
