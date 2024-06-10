using music_library_website.Data.Models;

namespace music_library_website.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
