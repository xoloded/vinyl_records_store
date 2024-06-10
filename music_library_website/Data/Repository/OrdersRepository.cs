using music_library_website.Data.Interfaces;
using music_library_website.Data.Models;

namespace music_library_website.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContext appDBContext;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDBContext appDBContext, ShopCart shopCart)
        {
            this.appDBContext = appDBContext;
            this.shopCart = shopCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContext.Add(order);

            foreach (var e in shopCart.ListShopItems) 
            {
                var orderDetail = new OrderDetail
                {
                    VinylRecord = e.VinylRecord,
                    Price = e.VinylRecord.Price,
                    Order = order
                };
                appDBContext.Add(orderDetail);
            }
            appDBContext.SaveChanges();
        }
    }
}
