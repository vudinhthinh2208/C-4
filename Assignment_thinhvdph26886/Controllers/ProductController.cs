using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;
using Assignment_thinhvdph26886.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_thinhvdph26886.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _productServices;
        private readonly ShoppingDbContext _context;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            _productServices = new ProductServices();
            _context = new ShoppingDbContext();
        }
        public IActionResult ShowAss()
        {
            var products = _productServices.GetProductsLinq();
            return View(products);
        }
        public IActionResult ShowListProduct()
        {
            var products = _productServices.GetAllProducts();
            return View(products);
        }
        public IActionResult ShowListProductKH()
        {
            var products = _productServices.GetAllProducts();
            return View(products);
        }
        public IActionResult ShowList()
        {
            var products = _productServices.GetAllProducts();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0) //Kiểm tra đường dẫn phù hợp
            {
                //Thực hiện sao chếp ảnh đó vào wwwroot
                //Tạo đường dẫn tới thư mục sao chép(nằm trong root)
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                    "images", imageFile.FileName); //vd: abc/wwwroot/iamges/xxx.png
                var stream = new FileStream(path, FileMode.Create); //Tạo 1 File Stream để tạo mới
                imageFile.CopyTo(stream); // Copy ảnh đc chịn vào stream đó.
                //Gán lại giá trị link ảnh (lúc này đã nằm trong root cho thuộc tính description)
                p.Description = imageFile.FileName;
            }
            _productServices.CreateProduct(p);
            return RedirectToAction("ShowListProduct");
        }
        public IActionResult Edit(Guid id)
        {

            return View(_productServices.GetProductById(id));
        }
        [HttpPost]
        
        public IActionResult Edit(Product p)
        {
            //var product = _productServices.GetProductById(p.ID);
            //if (p.AvailableQuantity >= 0 && p.Description != "" && p.Price > product.Price)
            //{
            //    product.Name = p.Name;
            //    product.Price = p.Price;
            //    product.AvailableQuantity = p.AvailableQuantity;
            //    product.Status = p.Status;
            //    product.Supplier = p.Supplier;
            //    product.Description = p.Description;
            //    product.Color=p.Color;
            //    _productServices.UpdateProduct(product);
            //    return RedirectToAction("ShowListProduct");
            //}
            //else return Content("Cảnh báo");
            _productServices.UpdateProduct(p);
            return RedirectToAction("ShowListProduct");
        }
        public IActionResult Details(Guid id)
        {
            return View(_productServices.GetProductById(id));
        }
        public IActionResult Delete(Guid id)
        {
            _productServices.DeleteProduct(id);
            return RedirectToAction("ShowListProduct");
        }
        [HttpPost]
        public ViewResult ShowListProductbyName(string title)
        {
            var a = _productServices.GetProductByName(title);
            return View("ShowListProduct", a);
        }
        [HttpPost]
        public ViewResult ShowListProductbyNames(string title)
        {
            var a = _productServices.GetProductByName(title);
            return View("ShowListProductKH", a);
        }
    }
}
