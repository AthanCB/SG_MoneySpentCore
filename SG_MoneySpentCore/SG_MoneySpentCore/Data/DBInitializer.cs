using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SG_MoneySpentCore.Models;

namespace SG_MoneySpentCore.Data
{
    public class DbInitializer
    {
        public static void Initialize(SpentContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category() {Id = Guid.NewGuid().ToString("N"), Name = "Food"},
                new Category() {Id = Guid.NewGuid().ToString("N"), Name = "Drinks"},
                new Category() {Id = Guid.NewGuid().ToString("N"), Name = "Clothing"},
                new Category() {Id = Guid.NewGuid().ToString("N"), Name = "Bills"},
                new Category() {Id = Guid.NewGuid().ToString("N"), Name = "Earn"}
                
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.Users.Add(new User() {Id = Guid.NewGuid().ToString("N"), Name = "Test User", Balance = 1000});
            

            context.SaveChanges();

        }
    }
}
