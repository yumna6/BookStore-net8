using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // DbSets for the entities
        public DbSet<AppUser> Users { get; set; }    // Represents the AppUser table
        public DbSet<Book> Books { get; set; }       // Represents the Book table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring many-to-many relationship between AppUser and Book
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.BooksPurchased)
                .WithMany(b => b.UsersPurchased)
                .UsingEntity(j => j.ToTable("UserBooksPurchased")); // Create a join table

            // You can add more configurations if necessary (e.g., property constraints, default values)
        }
    }
}
