using AssignmentDotStark.Contracts;
using AssignmentDotStark.Domain.Entity;
using AssignmentDotStark.Infrastructure;
using AssignmentDotStark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDotStark.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _dbContext;

        public ProductService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Save(ProductAddDataModel model)
        {
            var product = new Products
            {
                CreatedAt = DateTime.Now,
                ProductId = Guid.NewGuid(),
                ProdutName = model.ProductName,
                StockAvailable = model.StockAvailable,
                UpdatedAt = DateTime.Now
            };

            await _dbContext.Products.AddAsync(product).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync();

            return "Product addedd successfully!";
        }

        public List<ProductResultModel> GetAll()
        {
            return _dbContext.Products
                .Where(x => x.StockAvailable > 0)
                .Select(x => new ProductResultModel
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.ProdutName
                }).ToList();
        }

        public ProductResultModel GetById(string productId)
        {
            return GetAll().Where(x => x.ProductId.ToString() == productId).FirstOrDefault();
        }

        public async Task<string> Update(ProductUpdateDataModel model)
        {
            var product = _dbContext.Products.Where(x => x.ProductId.ToString() == model.ProductId).FirstOrDefault();

            if (product == null)
            {
                return await Task.FromResult("Product not found!");
            }

            product.StockAvailable = model.StockAvailable;
            product.UpdatedAt = DateTime.Now;

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();

            return "Product updated successfully!";
        }
    }
}
