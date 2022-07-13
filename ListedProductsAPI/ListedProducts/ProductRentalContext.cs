using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ListedProductsAPI.ListedProducts
{
    public partial class ProductRentalContext : DbContext
    {
        public ProductRentalContext()
        {
        }

        public ProductRentalContext(DbContextOptions<ProductRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ListedProduct> ListedProducts { get; set; }
        public virtual DbSet<ListedProductsPending> ListedProductsPendings { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProductRental;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ListedProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.AdTitle)
                    .HasMaxLength(160)
                    .IsUnicode(false)
                    .HasColumnName("AD_Title")
                    .HasComputedColumnSql("((((([Brand]+' ')+[Product_Type])+' ')+'Model : ')+[Model])", true);

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber).HasColumnName("Contact_Number");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProdUid)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("Prod_UID")
                    .HasComputedColumnSql("('LP'+CONVERT([varchar](20),[Product_ID]))", true);

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Category");

                entity.Property(e => e.ProductDescription)
                    .IsUnicode(false)
                    .HasColumnName("Product_Description");

                entity.Property(e => e.ProductImage)
                    .IsUnicode(false)
                    .HasColumnName("Product_Image");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Type");

                entity.Property(e => e.RentalDuration)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Rental_Duration");

                entity.Property(e => e.RentalFee).HasColumnName("Rental_Fee");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<ListedProductsPending>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__ListedPr__9834FB9A9228D509");

                entity.ToTable("ListedProducts_Pending");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber).HasColumnName("Contact_Number");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Post_Status");

                entity.Property(e => e.ProductCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Category");

                entity.Property(e => e.ProductDescription)
                    .IsUnicode(false)
                    .HasColumnName("Product_Description");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Image");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Type");

                entity.Property(e => e.RentalDuration)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Rental_Duration");

                entity.Property(e => e.RentalFee).HasColumnName("Rental_Fee");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");
            });

           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
