using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzeriaImpulsMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Addition>? Additions { get; set; }
        public DbSet<Component>? Components { get; set; }
        public DbSet<Drink>? Drinks { get; set; }
        public DbSet<DrinkSize>? DrinkSizes { get; set; }
        public DbSet<Pizza>? Pizzas { get; set; }
        public DbSet<PizzaComponent>? PizzaComponent { get; set; }
        public DbSet<PizzaSize>? PizzaSizes { get; set; }
        public DbSet<PizzaSizePizza>? PizzaSizePizza { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DrinkSize>()
                .Property(d => d.Size)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Drink>()
                .HasMany<DrinkSize>(ds => ds.DrinkSizes)
                .WithMany(d => d.Drinks);
                


            builder.Entity<PizzaSizePizza>()
                .HasKey(psp => new { psp.PizzaId, psp.PizzaSizeId });

            builder.Entity<PizzaSizePizza>()
                .HasOne<Pizza>(p => p.Pizza)
                .WithMany(p => p.PizzaSizePizzas)
                .HasForeignKey(p => p.PizzaId);

            builder.Entity<PizzaSizePizza>()
                .HasOne<PizzaSize>(ps => ps.PizzaSize)
                .WithMany(ps => ps.PizzaSizePizzas)
                .HasForeignKey(ps => ps.PizzaSizeId);


            builder.Entity<PizzaComponent>()
                .HasKey(pc => new { pc.PizzaId, pc.ComponentId });

            builder.Entity<PizzaComponent>()
                .HasOne<Pizza>(p => p.Pizza)
                .WithMany(p => p.PizzaComponents)
                .HasForeignKey(p => p.PizzaId);

            builder.Entity<PizzaComponent>()
                .HasOne<Component>(c => c.Component)
                .WithMany(c => c.PizzaComponents)
                .HasForeignKey(c => c.ComponentId);
        }
    }
}
