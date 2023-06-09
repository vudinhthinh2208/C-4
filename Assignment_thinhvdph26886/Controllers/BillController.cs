using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;
using Assignment_thinhvdph26886.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_thinhvdph26886.Controllers
{
    public class BillController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices productServices;
        private readonly IUserServices userServices;
        private readonly ICartDetailServices cartDetailServices;
        private readonly IBillDetailServices billDetailServices;
        private readonly IBillServices billServices;


        public BillController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productServices = new ProductServices();
            userServices = new UserServices();
            cartDetailServices = new CartDetailServices();
            billServices = new BillServices();
            billDetailServices = new BillDetailServices();
        }

        public IActionResult Pay()
        {
            var UserID = userServices.GetUserByName(HttpContext.Session.GetString("username"))[0].UserID;
            var listCartDetails = cartDetailServices.GetAllCartDetails().Where(c => c.UserID == UserID);
            //decimal tongtien = listCartDetails.Sum(c => c.Quantity * c.Product.Price);
            var Chuoi = "";
            var outOfStockProducts = listCartDetails
                             .Where(item => item.Quantity > productServices.GetProductById(item.IDSP).AvailableQuantity)
                             .Select(item => '"' + productServices.GetProductById(item.IDSP).Name);
            Chuoi = string.Join(" ", outOfStockProducts);

            if (listCartDetails.Any())
            {
                if (Chuoi == "")
                {
                    var bill = new Bill()
                    {
                        Id = Guid.NewGuid(),
                        CreateDate = DateTime.Now,
                        UserID = UserID,
                        Status = 1
                    };
                    billServices.CreateBill(bill);
                    var _product = productServices.GetAllProducts();
                    foreach (var item in listCartDetails)
                    {
                        var a = new BillDetails()
                        {
                            Id = Guid.NewGuid(),
                            IdHD = bill.Id,
                            IdSP = item.IDSP,
                            Quantity = item.Quantity,
                            Price = _product.FirstOrDefault(c=>c.ID == item.IDSP).Price,
                        };
                        billDetailServices.CreateBillDetail(a);
                        cartDetailServices.DeleteCartDetail(item.ID);
                        var product = productServices.GetProductById(item.IDSP);
                        product.AvailableQuantity -= item.Quantity;
                        productServices.UpdateProduct(product);
                    }
                    TempData["successful"] = "Thanh toán thanh toán thành công";
                    return RedirectToAction("ShowCart", "Cart");
                }
                else
                {
                    TempData["PayError"] = "Thanh toán không thành công do số lượng tồn của " + Chuoi + " không đủ !!!";

                }
            }
            return RedirectToAction("ShowCartUser", "Cart");
        }
        public IActionResult ShowListBill()
        {
            List<User> lstuser = new List<User>();
            lstuser = userServices.GetAllUsers();
            ViewData["User"] = new SelectList(lstuser, "UserID", "Username");
            var bill = billServices.GetAllBills();
            return View(bill);
        }
    }
}
