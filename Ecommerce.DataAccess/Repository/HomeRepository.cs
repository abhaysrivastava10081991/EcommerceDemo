using Ecommerce.DataModels.Models;
using EcommerceDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Repository
{
    public class HomeRepository
    {
        private ApplicationDbContext _dbContext;
        public HomeRepository(ApplicationDbContext dbContext) {
            _dbContext=dbContext;
        }

        public async Task<IEnumerable<Product>> DisplayProduct(string sTerm,int categoryId=0)
        {
           var products = _dbContext.Products
                .Where(p => p.Name.Contains(sTerm) || p.Description.Contains(sTerm))
                .Include(p => p.Category)
                .AsQueryable();

            if (categoryId > 0)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }
            return await products.ToListAsync();
        }
    }
}
