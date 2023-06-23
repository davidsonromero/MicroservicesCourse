using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
            IEnumerable<ProductModel> products = await _productService.FindAllProducts("");
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid) 
            {
                string? token = await HttpContext.GetTokenAsync("access_token");
                ProductModel response = await _productService.CreateProduct(model, token ?? "");
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(long Id)
        {
            string? token = await HttpContext.GetTokenAsync("access_token");
            ProductModel model = await _productService.FindProductById(Id, token ?? "");
            if (model != null) return View(model);
            return NotFound(Id);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                string? token = await HttpContext.GetTokenAsync("access_token");
                ProductModel response = await _productService.UpdateProduct(model, token ?? "");
                if (response != null) return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(long Id)
        {
            string? token = await HttpContext.GetTokenAsync("access_token");
            ProductModel model = await _productService.FindProductById(Id, token ?? "");
            if (model != null) return View(model);
            return NotFound(Id);
        }

        
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel Model)
        {
            string? token = await HttpContext.GetTokenAsync("access_token");
            bool response = await _productService.DeleteProductById(Model.Id, token ?? "");
            if (response) return RedirectToAction(nameof(ProductIndex));
            return View(Model);
        }
    }
}