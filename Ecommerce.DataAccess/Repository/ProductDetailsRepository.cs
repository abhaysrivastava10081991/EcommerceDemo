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

        public void Update(ProductDetails obj)
        {
            var objFromDb = _dbContext.ProductDetails.FirstOrDefault(o => o.Id== obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Size = obj.Size;
                objFromDb.Height = obj.Height;
                objFromDb.Width = obj.Width;
                objFromDb.HandleThickNess = obj.HandleThickNess;
                objFromDb.HandleShape = obj.HandleShape;
               
            }
        }
    }
}
