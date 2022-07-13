using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RegistrationAPI.ProductRental
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

        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<ListedProduct> ListedProducts { get; set; }
        public virtual DbSet<ListedProductsPending> ListedProductsPendings { get; set; }
        public virtual DbSet<ProdCity> ProdCities { get; set; }
        public virtual DbSet<ProdCountry> ProdCountries { get; set; }
        public virtual DbSet<ProdState> ProdStates { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserVerification> UserVerifications { get; set; }

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

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("Cart_Items");

                entity.Property(e => e.CartItemId).HasColumnName("Cart_itemID");

                entity.Property(e => e.ItemStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Item_Status");

                entity.Property(e => e.ListedProdId).HasColumnName("ListedProd_ID");

                entity.Property(e => e.ListedProdUid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ListedProd_UID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_ID");
            });

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

            modelBuilder.Entity<ProdCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("Prod_City");

                entity.Property(e => e.CityId)
                    .ValueGeneratedNever()
                    .HasColumnName("City_ID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("City_Name");

                entity.Property(e => e.StateId).HasColumnName("State_ID");
            });

            modelBuilder.Entity<ProdCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("Prod_Countries");

                entity.Property(e => e.CountryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Country_ID");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Country_Code");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Country_Name");
            });

            modelBuilder.Entity<ProdState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("Prod_States");

                entity.Property(e => e.StateId)
                    .ValueGeneratedNever()
                    .HasColumnName("State_ID");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.StateName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("State_Name");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("Product_Category");

                entity.Property(e => e.ProductCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_Category_ID");

                entity.Property(e => e.ProductCategory1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Category");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("Product_Type");

                entity.Property(e => e.ProductTypeId).HasColumnName("Product_Type_ID");

                entity.Property(e => e.ProductBrands)
                    .IsUnicode(false)
                    .HasColumnName("Product_Brands");

                entity.Property(e => e.ProductCategoryId).HasColumnName("Product_Category_ID");

                entity.Property(e => e.ProductType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Type");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.RegistrationId)
                    .HasName("PK__UserDeta__6EF58830D9356E9F");

                entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");

                entity.Property(e => e.Gmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.ProfilePicture).IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("UserID")
                    .HasComputedColumnSql("('PR'+CONVERT([varchar](20),[RegistrationID]))", true);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserVerification>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("User_Verification");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_ID");

                entity.Property(e => e.KycDocumentType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KYC_Document_Type");

                entity.Property(e => e.KycStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KYC_Status");

                entity.Property(e => e.UserKycProof)
                    .IsUnicode(false)
                    .HasColumnName("User_KYC_Proof");

                entity.Property(e => e.UserSelfie)
                    .IsUnicode(false)
                    .HasColumnName("User_Selfie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
