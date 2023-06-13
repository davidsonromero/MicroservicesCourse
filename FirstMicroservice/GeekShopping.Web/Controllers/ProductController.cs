using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            IEnumerable<ProductModel> products = await _productService.FindAllProducts();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid) 
            {
                ProductModel response = await _productService.CreateProduct(model);
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(long Id)
        {
            ProductModel model = await _productService.FindProductById(Id);
            if (model != null) return View(model);
            return NotFound(Id);
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                ProductModel response = await _productService.UpdateProduct(model);
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(long Id)
        {
            ProductModel model = await _productService.FindProductById(Id);
            if (model != null) return View(model);
            return NotFound(Id);
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel Model)
        {
            bool response = await _productService.DeleteProductById(Model.Id);
            if (response) return RedirectToAction(nameof(ProductIndex));
            return View(Model);
        }
    }
}