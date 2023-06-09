using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;
using Assignment_thinhvdph26886.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_thinhvdph26886.Controllers
{
    public class BillDetailController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBillDetailServices _billDetailServices;
        private readonly IProductServices productServices;

        public BillDetailController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _billDetailServices = new BillDetailServices();
            productServices = new ProductServices();
        }
        [HttpGet]
        public IActionResult BillDetail(Guid ID)
        {
            List<Product> lstproduct = new List<Product>();
            lstproduct = productServices.GetAllProducts();
            ViewData["Name"] = new SelectList(lstproduct, "ID", "Name");
            ViewData["Color"] = new SelectList(lstproduct, "ID", "Color");
            ViewData["Description"] = new SelectList(lstproduct, "ID", "Description");
            var a = _billDetailServices.GetBillDetailsByID(ID);
            List<BillDetails> list = new(_billDetailServices.GetAllBillDetails().Where(c => c.IdHD == ID));
            int tongtien = list.Sum(c => c.Quantity * c.Price);
            ViewBag.tongtien = tongtien;
            return View(a);
        }
    }
}
