using Mango.Services.ProductAPI.Models.DTO;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDTO _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDTO> productDTOs = await _productRepository.GetProducts();
                _response.Result = productDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                throw;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetById(int id)
        {
            try
            {
                ProductDTO productDTO = await _productRepository.GetProductById(id);
                _response.Result = productDTO;
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Create([FromBody] ProductDTO productDTO)
        {
            try
            {
                if(productDTO == null)
                {
                    _response.IsSucces = false;
                    _response.ErrorMessages = new List<string> { "Product null" };
                    return _response;
                }

                _response.Result = await _productRepository.CreateUpdateProduct(productDTO);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO == null)
                {
                    _response.IsSucces = false;
                    _response.ErrorMessages = new List<string> { "Product null" };
                    return _response;
                }

                _response.Result = await _productRepository.CreateUpdateProduct(productDTO);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccesss = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccesss;
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
