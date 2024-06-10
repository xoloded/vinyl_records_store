namespace music_library_website.Data.Models
{
	public class ShopCartItem
	{
		public long Id { get; set; }
		public VinylRecord VinylRecord { get; set; }
		public string ShopCartId { get; set; }
	}
}
