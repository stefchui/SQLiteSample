using SqLiteSample.Data.Models;

namespace SqLiteSample.Data.Repositories.Contacts
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<bool> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(string id);
    }
}
