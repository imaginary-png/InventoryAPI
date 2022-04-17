# InventoryAPI
Example API for a basic store inventory / customer cart system


An example API for a basic online store, using C# and [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

Handling inventory - adding, removing, updating items - description, name, price, stock.

Handling customer carts - adding, removing, updating quantity from a customer's personal cart.


Makes use of Json Web Tokens for Authentication / Authorization, separating endpoints into Anonymous, User, and Admin roles required.
[Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio) for generating user tables and handling Roles, Claims, Passwords, etc.


Seeded accounts:
  
user1 user1  
user2 user2  
admin admin
