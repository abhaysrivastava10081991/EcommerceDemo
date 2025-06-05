using Ecommerce.DataModels.Models;
using EcommerceDemo.Models;
namespace Ecommerce.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
