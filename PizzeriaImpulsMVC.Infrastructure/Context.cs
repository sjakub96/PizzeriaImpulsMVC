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
        public DbSet<Pizza>? Pizzas { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Pizza>()
                .HasMany<Component>(c => c.Components)
                .WithMany(p => p.Pizzas);

            
        }
    }
}
