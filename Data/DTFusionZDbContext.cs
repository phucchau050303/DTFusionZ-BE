using Microsoft.EntityFrameworkCore;
using DTFusionZ_BE.Entities;

namespace DTFusionZ_BE.Data
{
    public class DTFusionZDbContext : DbContext
    {
        public DTFusionZDbContext(DbContextOptions<DTFusionZDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OptionGroup> OptionGroups { get; set; }
        public DbSet<OptionValue> OptionValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId);

            modelBuilder.Entity<OptionValue>()
                .HasOne(ov => ov.OptionGroup)
                .WithMany(og => og.OptionValues)
                .HasForeignKey(ov => ov.OptionGroupId);

            modelBuilder.Entity<Order>()
                    .HasMany(o => o.OrderItems)
                    .WithOne(oi => oi.Order)
                    .HasForeignKey(oi => oi.OrderId);

            // OrderItem -> OrderItemOptions
            modelBuilder.Entity<OrderItem>()
                .HasMany(oi => oi.OrderItemOptions)
                .WithOne(oio => oio.OrderItem)
                .HasForeignKey(oio => oio.OrderItemId);

            modelBuilder.Entity<ItemOptionGroup>()
                .HasKey(iog => new { iog.ItemId, iog.OptionGroupId });

            modelBuilder.Entity<ItemOptionGroup>()
                .HasOne(iog => iog.Item)
                .WithMany(i => i.ItemOptionGroups)
                .HasForeignKey(iog => iog.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemOptionGroup>()
                .HasOne(iog => iog.OptionGroup)
                .WithMany()
                .HasForeignKey(iog => iog.OptionGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OptionValue>()
                .Property(ov => ov.PriceModifier)
                .HasPrecision(10, 2);
        }
    }
}