using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(newProduct);
                return RedirectToAction("Index");
            }
            
            return View(newProduct);
        }

        [HttpPost]
        public IActionResult EditPost(string id, ProductModel updatedProduct)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(updatedProduct.Id, updatedProduct);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }

        [HttpGet("{id}")]
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var model = _productService.Get(id);
            if (model == null)
            {
                return NotFound();
            }

            return View("Edit", model);
        }

        [HttpPost, ActionName("DeletePost")]
        public IActionResult DeletePost(string id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}