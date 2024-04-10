using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CuaHangLinhKien.Areas.Admin.Controllers
{
    [Area("Admin")]//attribute '[Area("Admin                                                                                    ")]'
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> CreateAdminAccount()
        {
            if(!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            var user = new IdentityUser
            {
                UserName = "truongleu7@gmail.com",
                Email = "truongleu7@gmail.com"
			};

            var result = await _userManager.CreateAsync(user,"Hutech@123");
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                return Content("Tao tai khoan admin thanh cong");
            }
            return BadRequest("tao admin that bai");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
