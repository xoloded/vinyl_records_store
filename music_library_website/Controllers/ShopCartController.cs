using Microsoft.AspNetCore.Mvc;
using music_library_website.Data.Interfaces;
using music_library_website.Data.Models;
using music_library_website.Data.Repository;
using music_library_website.ViewModels;

namespace music_library_website.Controllers
{
	public class ShopCartController : Controller
	{
		private IAllVinylRecords _vinylRecordRepository;
		private readonly ShopCart _shopCart;
		public ShopCartController(IAllVinylRecords vinylRecordRepository, ShopCart shopCart)
		{
			_vinylRecordRepository = vinylRecordRepository;
			_shopCart = shopCart;
		}
		public ViewResult Index() 
		{
			var shopCartItems = _shopCart.GetShopCartItems();
			_shopCart.ListShopItems = shopCartItems;

			var obj = new ShopCartViewModel
			{
				ShopCart = _shopCart
			};

			return View(obj); 
		}
		public RedirectToActionResult AddToShopCart(int id)
		{
			var vinylRecord = _vinylRecordRepository.VinylRecords.FirstOrDefault(e => e.Id == id);

			if (vinylRecord != null) 
			{
				_shopCart.AddToShopCart(vinylRecord);
			}
			return RedirectToAction("Index");
		}

	}
}
