using Microsoft.AspNetCore.Mvc;
using music_library_website.Data.Models;
using music_library_website.Data;
using music_library_website.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace music_library_website.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopCartItems();

            ModelState.Remove("OrderDetails");
            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                shopCart.DeleteAllItemsFromShopCart();
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ оформлен!";
            return View();
        }
	}
}
