using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDTO product);
        Task<T> UpdateProductAsync<T>(ProductDTO product);
        Task<T> DeleteProductAsync<T>(int id);

    }
}
