using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<InventoryItem> Inventory { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        //fluent api
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().HasOne(x => x.Cart).WithOne(x => x.Customer);

            builder.Entity<Cart>().HasMany(x => x.Items).WithOne(x => x.Cart);

            //setting up composite key for CartItem
            builder.Entity<CartItem>().HasKey(x => new {x.CartID, x.SKU});
        }
    }
}