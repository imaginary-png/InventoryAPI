using System;
using System.Linq;
using InventoryAPI.Models;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryAPI.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DatabaseContext>();

            // Look for plants.
            if (context.Inventory.Any())
                return; // DB has already been seeded.

            context.Customers.AddRange(
                new Customer
                {
                    CustomerID = "CUST1000",
                    Name = "Bob",
                    Address = null,
                    Phone = "0123456789",
                    Email = "123@fakeEmail.notreal"
                },
                new Customer
                {
                    CustomerID = "CUST1001",
                    Name = "James",
                    Address = null,
                    Phone = null,
                    Email = null
                },
                new Customer
                {
                    CustomerID = "CUST1002",
                    Name = "Alice",
                    Address = "123 fake st suburb postcode state",
                    Phone = null,
                    Email = "456@fakeEmail.notreal"
                }
            );

            context.Inventory.AddRange(
                new InventoryItem
                {
                    SKU = "SODA100",
                    Name = "Coca Cola",
                    Description = " 1.5L Coke, Drink",
                    Price = 2.95,
                    Stock = 100
                },
                new InventoryItem
                {
                    SKU = "SODA101",
                    Name = "Pepsi",
                    Description = " 1.5L Pepsi, Not the same as Coke",
                    Price = 2.95,
                    Stock = 100
                },
                new InventoryItem
                {
                    SKU = "MILK100",
                    Name = "Full Cream Milk",
                    Description = "1L Milk, Full Cream",
                    Price = 1.85,
                    Stock = 45
                },
                new InventoryItem
                {
                    SKU = "MILK101",
                    Name = "Skim Milk",
                    Description = "1L Milk, Low Fat, Skim",
                    Price = 1.85,
                    Stock = 50
                },
                new InventoryItem
                {
                    SKU = "COF100",
                    Name = "Iced Coffee",
                    Description = " 250ML Iced Coffee",
                    Price = 1.5,
                    Stock = 30
                },
                new InventoryItem
                {
                    SKU = "CHIP100",
                    Name = "BBQ Chips",
                    Description = "200g BBQ Chips",
                    Price = 2.35,
                    Stock = 15
                },
                new InventoryItem
                {
                    SKU = "CHIP101",
                    Name = "Salt and Vinegar Chips",
                    Description = "200g Salt and Vinegar Chips",
                    Price = 2.35,
                    Stock = 40
                },
                new InventoryItem
                {
                    SKU = "CHIP102",
                    Name = "Original Chips",
                    Description = "200g Original Chips",
                    Price = 2.35,
                    Stock = 40
                },
                new InventoryItem
                {
                    SKU = "CHAIR100",
                    Name = "Chair, Black",
                    Description = "It's a chair, you sit on it. Dimensions: 50cm x 40cm x 80cm",
                    Price = 45.95,
                    Stock = 12
                }
            );

            context.SaveChanges();
        }
    }
}