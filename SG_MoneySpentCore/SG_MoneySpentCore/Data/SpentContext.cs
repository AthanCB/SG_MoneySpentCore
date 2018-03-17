using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using SG_MoneySpentCore.Models;
using Microsoft.EntityFrameworkCore;

namespace SG_MoneySpentCore.Data
{
    public class SpentContext : DbContext
    {
        public SpentContext(DbContextOptions<SpentContext> options) : base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<Balance> Balances { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>().ToTable("Balances");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
