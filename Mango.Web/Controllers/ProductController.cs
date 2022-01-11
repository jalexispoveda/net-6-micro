using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDTO> list = new();
            var response = await _productService.GetProductsAsync<ResponseDTO>();
            if (response != null && response.IsSucces)
            {
                list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                List<ProductDTO> list = new();
                var response = await _productService.CreateProductAsync<ResponseDTO>(model);
                if (response != null && response.IsSucces)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }
    }
}
