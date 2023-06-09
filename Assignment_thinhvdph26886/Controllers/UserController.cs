using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;
using Assignment_thinhvdph26886.Services;
using Assignment_thinhvdph26886.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment_thinhvdph26886.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserServices _userServices;
        private readonly IRoleServices _roleServices;
        private readonly UserRoleVM _userRoleVM;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _userServices = new UserServices();
            _roleServices = new RoleServices();
            _userRoleVM = new UserRoleVM();
        }
        public IActionResult ShowListUser()
        {
            List<Role> lstrole = new List<Role>();
            lstrole = _roleServices.GetAllRoles();
            ViewData["NameRole"] = new SelectList(lstrole, "RoleID", "RoleName");
            var products = _userServices.GetAllUsers();
            return View(products);
        }
        public IActionResult Create()
        {
            _userRoleVM.Roles = _roleServices.GetAllRoles().ToList();
            return View(_userRoleVM);
        }

        [HttpPost]
        public IActionResult Create(User p)
        {

            _userServices.CreateUser(p);
            return RedirectToAction("ShowListUser");
        }
        public IActionResult Edit(Guid id)
        {
            var a = _roleServices.GetAllRoles();
            var b = _userServices.GetUserById(id);
            UserRoleVM userRoleVM = new UserRoleVM()
            {
                UserID = b.UserID,
                Status = b.Status,
                Username = b.Username,
                Password = b.Password,
                Roles = a
            };
            return View(userRoleVM);
        }
        [HttpPost]

        public IActionResult Edit(User p)
        {
            _userServices.UpdateUser(p);
            return RedirectToAction("ShowListUser");
        }
        public IActionResult Details(Guid id)
        {
            var user = _userServices.GetUserById(id);
            var rolename = _roleServices.GetAllRoles().FirstOrDefault(c => c.RoleID == user.Role).RoleName;
            DetailRoleVM detailRoleVM = new DetailRoleVM()
            {
                RoleName = rolename,
                Password = user.Password,
                Username = user.Username,
                Status = user.Status
            };
            return View(detailRoleVM);
        }
        public IActionResult Delete(Guid id)
        {
            _userServices.DeleteUser(id);
            return RedirectToAction("ShowListUser");
        }

    }
}
