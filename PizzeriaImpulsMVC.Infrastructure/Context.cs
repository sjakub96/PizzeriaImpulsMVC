using Microsoft.EntityFrameworkCore;
using PizzeriaImpulsMVC.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PizzeriaImpulsMVC.Infrastructure
{
    public class Context : IdentityDbContext<UserAccount>
    {
        public DbSet<Addition>? Additions { get; set; }
        public DbSet<Component>? Components { get; set; }
        public DbSet<Drink>? Drinks { get; set; }
        public DbSet<Pizza>? Pizzas { get; set; }
        public DbSet<ComponentPizza> ComponentPizzas { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            

            builder.Entity<ComponentPizza>()
            .HasKey(t => new { t.PizzaId, t.ComponentId });

            builder.Entity<ComponentPizza>()
                .HasOne<Pizza>(p => p.Pizza)
                .WithMany(pc => pc.ComponentPizzas)
                .HasForeignKey(pt => pt.PizzaId);

            builder.Entity<ComponentPizza>()
                .HasOne<Component>(pt => pt.Component)
                .WithMany(t => t.ComponentPizzas)
                .HasForeignKey(pt => pt.ComponentId);

            //builder.Entity<UserAddress>()
               // .Property(x => x.UserAccountId).HasColumnType("nvarchar(450)");
        }

    }
}
