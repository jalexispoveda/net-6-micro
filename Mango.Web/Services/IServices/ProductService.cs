using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> CreateProductAsync<T>(ProductDTO product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = product,
                Url = StaticDetails.ProductApiBaseUrl + "api/products",
                AcessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.ProductApiBaseUrl + "api/products/" + id,
                AcessToken = ""
            });
        }

        public async Task<T> GetProductAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductApiBaseUrl + "api/products",
                AcessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductApiBaseUrl + "api/products/" + id,
                AcessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDTO product)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = product,
                Url = StaticDetails.ProductApiBaseUrl + "api/products",
                AcessToken = ""
            });
        }
    }
}
