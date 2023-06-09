using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;
using Assignment_thinhvdph26886.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_thinhvdph26886.Controllers
{
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleServices _roleServices;

        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;
            _roleServices = new RoleServices();
        }
        public IActionResult ShowListRole()
        {
            var products = _roleServices.GetAllRoles();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role r)
        {
            _roleServices.CreateRole(r);
            return RedirectToAction("ShowListRole");
        }
        public IActionResult Edit(Guid id)
        {
            return View(_roleServices.GetRoleById(id));
        }
        [HttpPost]

        public IActionResult Edit(Role r)
        {
            _roleServices.UpdateRole(r);
            return RedirectToAction("ShowListRole");
        }
        public IActionResult Details(Guid id)
        {
            return View(_roleServices.GetRoleById(id));
        }
        public IActionResult Delete(Guid id)
        {
            _roleServices.DeleteRole(id);
            return RedirectToAction("ShowListRole");
        }
    }
}
