using Microsoft.EntityFrameworkCore;

namespace music_library_website.Data.Models
{
	public class ShopCart
	{
		private readonly AppDBContext appDBContext;
		public ShopCart(AppDBContext appDBContent)
		{
			this.appDBContext = appDBContent;
		}

		public string ShopCartId { get; set; }
		public List<ShopCartItem> ListShopItems { get; set; }

		public static ShopCart GetShopCart(IServiceProvider service)
		{
			ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = service.GetService<AppDBContext>();
			string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", shopCartId);

			return new ShopCart(context) { ShopCartId = shopCartId };
		}
		public void AddToShopCart(VinylRecord vinylRecord)
		{
			appDBContext.ShopCartItems.Add(new ShopCartItem
			{
				ShopCartId = ShopCartId,
				VinylRecord = vinylRecord,
			});

			appDBContext.SaveChanges();
		}
		public void DeleteAllItemsFromShopCart()
		{
			appDBContext.ShopCartItems.RemoveRange(appDBContext.ShopCartItems.Where(e => e.ShopCartId == ShopCartId));
			appDBContext.SaveChanges();
		}
		public List<ShopCartItem> GetShopCartItems()
		{
			return appDBContext.ShopCartItems.Where(e => e.ShopCartId == ShopCartId).Include(e => e.VinylRecord).ToList();
		}
	}
}
