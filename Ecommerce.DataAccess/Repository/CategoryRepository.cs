using Ecommerce.DataAccess.Repository.IRepository;
using EcommerceDemo.Data;
using EcommerceDemo.Models;

namespace Ecommerce.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        private ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Category obj)
        {
            _dbContext.Categories.Update(obj);
        }
    }
}
