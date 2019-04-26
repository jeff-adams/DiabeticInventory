using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EDIS.WebApp.Models
{
    public class EDISContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set;}
        public DbSet<Prescription> Prescription { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EDIS.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(i => i.StockNumber)
                    .HasName("Stock Number");

                entity.Property(i => i.StockNumber)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(p => p.RxNumber)
                    .HasName("Prescription Number");
                
                entity.Property(p => p.RxNumber)
                    .ValueGeneratedNever();

                entity.HasOne(p => p.StockNumberNavigation)
                    .WithMany(i => i.Prescription)
                    .HasForeignKey(x => x.StockNumber);
            });
        }
    }
}