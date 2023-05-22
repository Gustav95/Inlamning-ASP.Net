using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        

        private readonly TagService _tagService;
        private readonly ProductService _productService;

        public ProductsController(TagService tagService, ProductService productService)
        {
            _tagService = tagService;
            _productService = productService;
        }




        public  IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.Tags = await _tagService.GetTagsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel, string[] tags )
        {
            if (ModelState.IsValid)
            {
              if (await _productService.CreateAsync(productRegistrationViewModel))
                {
                    await _productService.AddProductTagsAsync(productRegistrationViewModel, tags);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Somthing went wrong");
                
            }

            ViewBag.Tags = await _tagService.GetTagsAsync(tags);
            return View(productRegistrationViewModel);
        }

        public IActionResult Search()
        {
            ViewData["Titel"] = "Search for products";
            return View();
        }






        public async Task<IActionResult> Detail(int Id)
        {
            ProductModel model = await _productService.GetSpecificProduct(Id);
            return View(model);
        }

    }
}
