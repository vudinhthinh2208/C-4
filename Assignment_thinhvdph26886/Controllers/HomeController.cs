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

namespace Assignment_thinhvdph26886.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShoppingDbContext _context;
        private readonly IRoleServices _roleServices;
        private readonly ICartServices _cartService;
        public HomeController(ILogger<HomeController> logger, IRoleServices roleServices,ICartServices cartServices)
        {
            _logger = logger;
            _context = new ShoppingDbContext();
            _roleServices = roleServices;
            _cartService = cartServices;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            { 
                var user = _context.Users.FirstOrDefault(s => s.Username.Equals(username) && s.Password.Equals(password));
                var role = _roleServices.GetRoleById(user.Role).RoleName;

                if (user != null)
                {
                    _cartService.CreateCart(new Cart()
                    {
                        UserID = user.UserID,
                        Description = ""
                    }); 
                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("role", role);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("role", "");
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}