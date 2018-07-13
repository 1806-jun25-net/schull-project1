using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.App.Models
{
    public partial class PizzeriaContext : DbContext
    {
        public PizzeriaContext()
        {
        }

        public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }
        public virtual DbSet<PizzaOrderPizzaJunction> PizzaOrderPizzaJunction { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Locat__2BFE89A6");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.Property(e => e.OrderValue).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__Locat__634EBE90");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__UserI__625A9A57");
            });

            modelBuilder.Entity<PizzaOrderPizzaJunction>(entity =>
            {
                entity.ToTable("PizzaOrder_Pizza_Junction");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PizzaOrderPizzaJunction)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaOrderPizzaJunction)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__536C85E46EC1C975")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
