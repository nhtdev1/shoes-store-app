namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShoesStore : DbContext
    {
        public ShoesStore()
            : base("name=ShoesStore")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PayMethod> PayMethods { get; set; }
        public virtual DbSet<PhotoDescription> PhotoDescriptions { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BestSellerProduct> BestSellerProducts { get; set; }
        public virtual DbSet<PhotoOfShoesView> PhotoOfShoesViews { get; set; }
        public virtual DbSet<PriceOfShoesView> PriceOfShoesViews { get; set; }
        public virtual DbSet<ProductSizeView> ProductSizeViews { get; set; }
        public virtual DbSet<ProductView> ProductViews { get; set; }
        public virtual DbSet<TemplateProductView> TemplateProductViews { get; set; }
        public virtual DbSet<TopTrendingView> TopTrendingViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Account1)
                .WithOptional(e => e.Account2)
                .HasForeignKey(e => e.ManageID);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Authorizations)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("AccountAuthorization").MapLeftKey("AccID").MapRightKey("AuID"));

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Category1)
                .WithOptional(e => e.Category2)
                .HasForeignKey(e => e.CategoryParentID);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Prices)
                .WithMany(e => e.Colors)
                .Map(m => m.ToTable("ColorPrice").MapLeftKey("ColorID").MapRightKey("PriceID"));

            modelBuilder.Entity<Feedback>()
                .Property(e => e.UContent)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<PhotoDescription>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shoe>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.Shoe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shoe>()
                .HasMany(e => e.Sizes)
                .WithMany(e => e.Shoes)
                .Map(m => m.ToTable("ShoeSize").MapLeftKey("ShoeID").MapRightKey("SizeID"));

            modelBuilder.Entity<Size>()
                .Property(e => e.Number)
                .HasPrecision(18, 1);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhotoOfShoesView>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<ProductSizeView>()
                .Property(e => e.Number)
                .HasPrecision(18, 1);

            modelBuilder.Entity<ProductView>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<TemplateProductView>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<TopTrendingView>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
