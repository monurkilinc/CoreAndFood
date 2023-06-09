using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CoreAndFood1.Data.Model;
using CoreAndFood1.Data.Models;

namespace CoreAndFood1.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

		//Login İşlemi için açılan Index

		[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Admin p) 
        {
            var datavalue=c.Admins.FirstOrDefault(x=>x.UserName==p.UserName && x.Password==p.Password);
            if (datavalue!=null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,p.UserName),

                };

                var useridentity=new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal=new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Category");
            }
            return View();

        }

		//LogOut İşlemi için açılan Index(Layout Logut kısmına yol ekle!)

		[HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
