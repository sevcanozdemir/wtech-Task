using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Service;
using Twitter.Model.Entities;

namespace Twitter.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoreService<User> _userService;
        private readonly IWebHostEnvironment _env;

        public AccountController(ICoreService<User> userService,IWebHostEnvironment env)
        {
            _userService = userService;
            _env = env;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            { 
                if (_userService.Any(x => x.Email == user.Email && x.Password == user.Password))
                {
                    User logged = _userService.GetByDefault(x =>
                        x.Email == user.Email && x.Password == user.Password);


                    var claims = new List<Claim>()
                        {
                        new Claim("ID", logged.ID.ToString()),
                        new Claim(ClaimTypes.Name, logged.Fullname),
                        new Claim("Username", logged.Username),
                        new Claim(ClaimTypes.Email, logged.Email),
                        };

                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    TempData["ErrorMessage"] = "";
                    return View(user);
                }

            }
            else
            {
                TempData["ErrorMessage"] = "";
            }
            return View(user);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Any(x => x.Username == user.Username))
                {
                    TempData["ErrorMessage"] = "";
                    return View(user);
                }
                if (_userService.Any(x => x.Email == user.Email))
                {
                    TempData["ErrorMessage"] = "E-posta adresi başka bir hesaba ait.";
                    return View(user);
                }

                if (_userService.Add(user)) ;

                else
                    TempData["ErrorMessage"] = "";
            }
            else
            {
                TempData["ErrorMessage"] = "";
            }
            return RedirectToAction("Login");
        }
    

    }
}
