namespace WxShop_Model
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Fish_Model : DbContext
	{
		public Fish_Model()
			: base("name=Fish_Model")
		{
		}

		public virtual DbSet<Address> Address { get; set; }
		public virtual DbSet<Banner> Banner { get; set; }
		public virtual DbSet<Customar> Customar { get; set; }
		public virtual DbSet<Favarite> Favarite { get; set; }
		public virtual DbSet<OrderChild> OrderChild { get; set; }
		public virtual DbSet<OrderFath> OrderFath { get; set; }
		public virtual DbSet<PayMethod> PayMethod { get; set; }
		public virtual DbSet<ProductInfo> ProductInfo { get; set; }
		public virtual DbSet<ProductReview> ProductReview { get; set; }
		public virtual DbSet<ProductSecondSort> ProductSecondSort { get; set; }
		public virtual DbSet<ProductSort> ProductSort { get; set; }
		public virtual DbSet<ProImage> ProImage { get; set; }
		public virtual DbSet<SeachProduct> SeachProduct { get; set; }
		public virtual DbSet<ShoppongCart> ShoppongCart { get; set; }
		public virtual DbSet<ShowNews> ShowNews { get; set; }
		public virtual DbSet<Specification> Specification { get; set; }
		public virtual DbSet<Stock> Stock { get; set; }
		public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Banner>()
				.Property(e => e.P_Code)
				.IsUnicode(false);

			modelBuilder.Entity<Customar>()
				.Property(e => e.Phone)
				.IsUnicode(false);

			modelBuilder.Entity<Customar>()
				.HasMany(e => e.Favarite)
				.WithOptional(e => e.Customar)
				.HasForeignKey(e => e.Cid);

			modelBuilder.Entity<Customar>()
				.HasMany(e => e.ProductReview)
				.WithRequired(e => e.Customar)
				.HasForeignKey(e => e.Cid)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Customar>()
				.HasMany(e => e.SeachProduct)
				.WithOptional(e => e.Customar)
				.HasForeignKey(e => e.Cid);

			modelBuilder.Entity<Favarite>()
				.Property(e => e.Pcode)
				.IsUnicode(false);

			modelBuilder.Entity<Favarite>()
				.Property(e => e.Price)
				.HasPrecision(19, 4);

			modelBuilder.Entity<OrderChild>()
				.Property(e => e.Pcode)
				.IsUnicode(false);

			modelBuilder.Entity<OrderChild>()
				.Property(e => e.TotalPrice)
				.HasPrecision(19, 4);

			modelBuilder.Entity<OrderFath>()
				.Property(e => e.ExpresPrice)
				.HasPrecision(19, 4);

			modelBuilder.Entity<OrderFath>()
				.Property(e => e.TotalPrice)
				.HasPrecision(19, 4);

			modelBuilder.Entity<ProductInfo>()
				.Property(e => e.Code)
				.IsUnicode(false);

			modelBuilder.Entity<ProductInfo>()
				.Property(e => e.Price)
				.HasPrecision(19, 4);

			modelBuilder.Entity<ProductInfo>()
				.Property(e => e.Content)
				.IsUnicode(false);

			modelBuilder.Entity<ProductInfo>()
				.Property(e => e.img)
				.IsFixedLength();

			modelBuilder.Entity<ProductInfo>()
				.Property(e => e.ProductSortCode)
				.IsUnicode(false);

			modelBuilder.Entity<ProductInfo>()
				.HasMany(e => e.Banner)
				.WithOptional(e => e.ProductInfo)
				.HasForeignKey(e => e.P_Code)
				.WillCascadeOnDelete();

			modelBuilder.Entity<ProductInfo>()
				.HasMany(e => e.Favarite)
				.WithOptional(e => e.ProductInfo)
				.HasForeignKey(e => e.Pcode)
				.WillCascadeOnDelete();

			modelBuilder.Entity<ProductInfo>()
				.HasMany(e => e.ProductReview)
				.WithOptional(e => e.ProductInfo)
				.HasForeignKey(e => e.Pcode)
				.WillCascadeOnDelete();

			modelBuilder.Entity<ProductInfo>()
				.HasMany(e => e.ProImage)
				.WithRequired(e => e.ProductInfo)
				.HasForeignKey(e => e.Pcode);

			modelBuilder.Entity<ProductInfo>()
				.HasMany(e => e.Stock)
				.WithOptional(e => e.ProductInfo)
				.HasForeignKey(e => e.BillId)
				.WillCascadeOnDelete();

			modelBuilder.Entity<ProductInfo>()
				.HasMany(e => e.Specification)
				.WithRequired(e => e.ProductInfo)
				.HasForeignKey(e => e.ProCode)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ProductReview>()
				.Property(e => e.Pcode)
				.IsUnicode(false);

			modelBuilder.Entity<ProductSecondSort>()
				.Property(e => e.Code)
				.IsUnicode(false);

			modelBuilder.Entity<ProductSecondSort>()
				.Property(e => e.FirstCode)
				.IsUnicode(false);

			modelBuilder.Entity<ProductSecondSort>()
				.Property(e => e.img)
				.IsUnicode(false);

			modelBuilder.Entity<ProductSort>()
				.Property(e => e.Code)
				.IsUnicode(false);

			modelBuilder.Entity<ProImage>()
				.Property(e => e.Pcode)
				.IsUnicode(false);

			modelBuilder.Entity<ShoppongCart>()
				.Property(e => e.Pcode)
				.IsUnicode(false);

			modelBuilder.Entity<ShoppongCart>()
				.Property(e => e.Price)
				.HasPrecision(19, 4);

			modelBuilder.Entity<ShoppongCart>()
				.Property(e => e.Totale)
				.HasPrecision(19, 4);

			modelBuilder.Entity<ShowNews>()
				.Property(e => e.Content)
				.IsUnicode(false);

			modelBuilder.Entity<Specification>()
				.Property(e => e.ProCode)
				.IsUnicode(false);

			modelBuilder.Entity<Stock>()
				.Property(e => e.BillId)
				.IsUnicode(false);
		}
	}
}
