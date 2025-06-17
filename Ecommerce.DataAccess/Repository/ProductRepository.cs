using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataModels.Models;
using EcommerceDemo.Data;
using EcommerceDemo.Models;
using System.Runtime.Remoting;

namespace Ecommerce.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Product obj)
        {
            var objFromDb = _dbContext.Products.FirstOrDefault(o => o.ID == obj.ID);
            if(objFromDb!=null)
            {
                objFromDb.Description = obj.Description;
                objFromDb.Category = obj.Category;
                objFromDb.Discount = obj.Discount;
                objFromDb.Name = obj.Name;
                if(objFromDb.ImageUrl!=null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }

        
    }
}
