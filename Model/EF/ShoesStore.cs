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
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<ShoeSizePrice> ShoeSizePrices { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<ViewListAllProduct> ViewListAllProducts { get; set; }
        public virtual DbSet<ViewShoeDetail> ViewShoeDetails { get; set; }
        public virtual DbSet<ViewTopTrending> ViewTopTrendings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ShoeSizePrice>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ShoeSizePrice>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Size>()
                .Property(e => e.Number)
                .HasPrecision(18, 1);

            modelBuilder.Entity<ViewListAllProduct>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ViewListAllProduct>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<ViewShoeDetail>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ViewShoeDetail>()
                .Property(e => e.SizeNumber)
                .HasPrecision(18, 1);

            modelBuilder.Entity<ViewShoeDetail>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<ViewTopTrending>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ViewTopTrending>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
