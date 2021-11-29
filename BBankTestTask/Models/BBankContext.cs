using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BBankTestTask.Models
{
    public partial class BBankContext : DbContext
    {
        public BBankContext(DbContextOptions<BBankContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-89NNUEG;Initial Catalog=BBank;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryName)
                    .HasName("PK__Category__8517B2E18BAB5C7F");

                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(60);

                entity.Property(e => e.CategotyDescription)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('Нет описания')");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasDefaultValueSql("('Не установлено')");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('Нет описания')");

                entity.Property(e => e.ProductGenaralNote)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('Нет примечания')");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(5, 3)");

                entity.Property(e => e.ProductSpeciallNote)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("('Нет примечания')");

                entity.HasOne(d => d.CategoryNameNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__Categor__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
