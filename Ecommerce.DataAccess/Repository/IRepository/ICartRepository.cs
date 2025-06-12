
using Ecommerce.DataModels.Models;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface ICartRepository 
    {
        Task<int> AddItem(int productId,int unitPrice, int qty);
        Task<int> RemoveItem(int productId);
        Task<ShoppingCart> GetUserCart();
        Task<int> getCartItemCount(string userId = "");
        Task<ShoppingCart> getCart(string userId);
        Task<bool> DoCheckOut();
    }
}
