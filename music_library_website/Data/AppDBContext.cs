using Microsoft.EntityFrameworkCore;
using music_library_website.Data.Models;

namespace music_library_website.Data
{
	public class AppDBContext : DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>()
				.HasMany(q => q.VinylRecords)
				.WithOne(q => q.Category)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<VinylRecord>()
				.HasOne(q => q.Category)
				.WithMany(q => q.VinylRecords)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Order>()
				.HasMany(q => q.OrderDetails)
				.WithOne(q => q.Order)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<OrderDetail>()
				.HasOne(q => q.Order)
				.WithMany(q => q.OrderDetails)
				.OnDelete(DeleteBehavior.Restrict);
		}
		public DbSet<VinylRecord> VinylRecords { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
