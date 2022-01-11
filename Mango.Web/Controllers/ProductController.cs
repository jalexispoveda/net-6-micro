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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ResponseDTO>(model);
                if (response != null && response.IsSucces)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ResponseDTO>(productId);
            if (response != null && response.IsSucces)
            {
                ProductDTO model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync<ResponseDTO>(model);
                if (response != null && response.IsSucces)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }
    }
}
