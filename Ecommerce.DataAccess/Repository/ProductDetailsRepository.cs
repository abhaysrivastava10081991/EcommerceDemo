using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataModels.Models;
using EcommerceDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
    public class ProductDetailsRepository :Repository<ProductDetails>,IProductDetailsRepository
    {
        private ApplicationDbContext _dbContext;
        public ProductDetailsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
