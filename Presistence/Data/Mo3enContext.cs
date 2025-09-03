using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data
{
    public class Mo3enContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Mo3een;Trusted_Connection=true;trustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderItem>(order => order.HasKey(x => new { x.ProductId, x.OrderId }));
            builder.Ignore<Address>();
        }
        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Assistant> Assistant { get; set; }

        public DbSet<AssistantOrder> AssistantOrder { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Reviews> Reviews { get; set; }

        public DbSet<StoreOrder> StoreOrder { get; set; }

    }
}
