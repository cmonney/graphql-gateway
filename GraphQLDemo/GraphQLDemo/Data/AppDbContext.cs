using GraphQLDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQLDemo.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure a converter to ensure DateTime values are stored as UTC
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Name).IsRequired().HasMaxLength(200);
                entity.Property(m => m.Description).IsRequired().HasMaxLength(200);
                entity.Property(m => m.Price).IsRequired();
                entity.Property(m => m.ImageUrl).HasMaxLength(200);
                entity.Property(m => m.CategoryId).IsRequired();
                entity.HasIndex(m => m.Name).IsUnique();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(200);
                entity.Property(c => c.ImageUrl).HasMaxLength(200);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.CustomerName).IsRequired().HasMaxLength(200);
                entity.Property(r => r.Email).IsRequired().HasMaxLength(200);
                entity.Property(r => r.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(r => r.SpecialRequest).HasMaxLength(200);
                entity.Property(r => r.ReservationDate)
                      .IsRequired()
                      .HasConversion(dateTimeConverter);
                entity.Property(r => r.PartySize).IsRequired();
            });

            // Seed static data for Categories and Menus
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Appetizers", ImageUrl = "https://example.com/categories/appetizers.jpg" },
                new Category { Id = 2, Name = "Main Course", ImageUrl = "https://example.com/categories/main-course.jpg" },
                new Category { Id = 3, Name = "Desserts", ImageUrl = "https://example.com/categories/desserts.jpg" }
            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu { Id = 1, Name = "Chicken Wings", Description = "Spicy chicken wings served with blue cheese dip.", Price = 9.99m, ImageUrl = "https://example.com/menus/chicken-wings.jpg", CategoryId = 1 },
                new Menu { Id = 2, Name = "Steak", Description = "Grilled steak with mashed potatoes and vegetables.", Price = 24.50m, ImageUrl = "https://example.com/menus/steak.jpg", CategoryId = 2 },
                new Menu { Id = 3, Name = "Chocolate Cake", Description = "Decadent chocolate cake with a scoop of vanilla ice cream.", Price = 6.95m, ImageUrl = "https://example.com/menus/chocolate-cake.jpg", CategoryId = 3 }
            );

            // Seed static data for Reservations with hardcoded UTC values
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = 1,
                    CustomerName = "John Doe",
                    Email = "johndoe@example.com",
                    PhoneNumber = "555-123-4567",
                    PartySize = 2,
                    SpecialRequest = "No nuts in the dishes, please.",
                    ReservationDate = new DateTime(2023, 12, 15, 18, 0, 0, DateTimeKind.Utc)
                },
                new Reservation
                {
                    Id = 2,
                    CustomerName = "Jane Smith",
                    Email = "janesmith@example.com",
                    PhoneNumber = "555-987-6543",
                    PartySize = 4,
                    SpecialRequest = "Gluten-free options required.",
                    ReservationDate = new DateTime(2023, 12, 22, 19, 0, 0, DateTimeKind.Utc)
                },
                new Reservation
                {
                    Id = 3,
                    CustomerName = "Michael Johnson",
                    Email = "michaeljohnson@example.com",
                    PhoneNumber = "555-789-0123",
                    PartySize = 6,
                    SpecialRequest = "Celebrating a birthday.",
                    ReservationDate = new DateTime(2023, 12, 29, 20, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}