using Assignment_thinhvdph26886.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using Assignment_thinhvdph26886.IServices;
using System.Data;
using Assignment_thinhvdph26886.Services;
using Assignment_thinhvdph26886.Views.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_thinhvdph26886.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices productServices;
        private readonly IUserServices userServices;
        private readonly ICartDetailServices cartDetailServices;


        public CartController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productServices = new ProductServices();
            userServices = new UserServices();
            cartDetailServices = new CartDetailServices();

        }
        public IActionResult ShowCart()
        {
            List<Product> lstproduct = new List<Product>();
            lstproduct = productServices.GetAllProducts();
            ViewData["Name"] = new SelectList(lstproduct, "ID", "Name");
            ViewData["Color"] = new SelectList(lstproduct, "ID", "Color");
            ViewData["Description"] = new SelectList(lstproduct, "ID", "Description");
            ViewData["Price"] = new SelectList(lstproduct, "ID", "Price");
            var username = HttpContext.Session.GetString("username");
            var user = userServices.GetAllUsers().FirstOrDefault(c => c.Username == username).UserID;
            List<CartDetails> cartDetails = new(cartDetailServices.GetAllCartDetails().Where(c => c.UserID == user));
            int tongtien = cartDetails.Sum(c => c.Quantity * c.Product.Price);
            ViewBag.tongtien = tongtien;
            return View(cartDetails);
        }
        [HttpPost]
        public IActionResult AddToCart(CartView a)
        {
            var product = productServices.GetProductById(a.ProductID);
            var username = HttpContext.Session.GetString("username");
            var user = userServices.GetAllUsers().FirstOrDefault(c => c.Username == username).UserID;
            var cart = cartDetailServices.GetAllCartDetails().FirstOrDefault(c => c.UserID == user && c.IDSP == product.ID);
            if (cart != null)
            {
                if (cart.Quantity + a.Quantity <= product.AvailableQuantity)
                {
                    cart.Quantity += a.Quantity;
                    cartDetailServices.UpdateCartDetail(cart);
                }
                else
                {
                    cart.Quantity = product.AvailableQuantity;
                    cartDetailServices.UpdateCartDetail(cart);
                    TempData["bug"] = "Số lượng tồn trong kho không đủ !";
                    return RedirectToAction("Details", "Home", new { id = cart.IDSP });
                }

            }
            else
            {
                var cartdetail = new CartDetails()
                {
                    UserID = user,
                    IDSP = product.ID,
                    Quantity = a.Quantity,
                };
                cartDetailServices.CreateCartDetail(cartdetail);
            }
            return RedirectToAction("ShowCart");
        }

        public IActionResult Delete(Guid id)
        {
            cartDetailServices.DeleteCartDetail(id);
            return RedirectToAction("ShowCart");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}