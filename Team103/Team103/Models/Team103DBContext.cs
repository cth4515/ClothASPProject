using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Team103.Models
{
    public partial class Team103DBContext : DbContext
    {
        public Team103DBContext()
        {
        }

        public Team103DBContext(DbContextOptions<Team103DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblOrderLine> TblOrderLine { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=buscissql1601\\cisweb;Database=Team103DB;User ID=larger;Password=scale;");
            
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryPk);

                entity.ToTable("tblCategory");

                entity.Property(e => e.CategoryPk).HasColumnName("CategoryPK");

                entity.Property(e => e.ImageFile)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderPk);

                entity.ToTable("tblOrder");

                entity.Property(e => e.OrderPk).HasColumnName("OrderPK");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShipCity).HasMaxLength(50);

                entity.Property(e => e.ShipState).HasMaxLength(5);

                entity.Property(e => e.ShipStreet).HasMaxLength(100);

                entity.Property(e => e.ShipZip).HasMaxLength(10);

                entity.Property(e => e.UserFk).HasColumnName("UserFK");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrder_tblUser");
            });

            modelBuilder.Entity<TblOrderLine>(entity =>
            {
                entity.HasKey(e => e.OrderLinePk);

                entity.ToTable("tblOrderLine");

                entity.Property(e => e.OrderLinePk).HasColumnName("OrderLinePK");

                entity.Property(e => e.OrderFk).HasColumnName("OrderFK");

                entity.Property(e => e.ProductFk).HasColumnName("ProductFK");

                entity.HasOne(d => d.OrderFkNavigation)
                    .WithMany(p => p.TblOrderLine)
                    .HasForeignKey(d => d.OrderFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrderLine_tblOrder");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.TblOrderLine)
                    .HasForeignKey(d => d.ProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrderLine_tblProduct");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductPk);

                entity.ToTable("tblProduct");

                entity.Property(e => e.ProductPk).HasColumnName("ProductPK");

                entity.Property(e => e.CategoryFk).HasColumnName("CategoryFK");

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.ImageFile).HasMaxLength(50);

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Size)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.CategoryFkNavigation)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.CategoryFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProduct_tblCategory");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserPk);

                entity.ToTable("tblUser");

                entity.Property(e => e.UserPk).HasColumnName("UserPK");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Role).HasMaxLength(10);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
