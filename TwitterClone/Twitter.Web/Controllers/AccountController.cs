using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Index()
        {
            return View();
        }

    }
}
