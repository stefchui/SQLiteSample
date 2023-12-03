using Microsoft.EntityFrameworkCore;
using SqLiteSample.Data.DataContexts;
using SqLiteSample.Data.Models;
using SqLiteSample.Data.Repositories.Contracts;

namespace SqLiteSample.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await _context
                            .Products
                            .ToListAsync();
        }
        public async Task<Product> GetProduct(string id)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));
            return await _context
                           .Products
                           .FindAsync(id);
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            await _context
                .Products
                .AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> UpdateProductAsync(Product product)
        {
            _context
                .Products
                .Update(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var product = await GetProduct(id);

            _context
                .Products
                .Remove(product);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}