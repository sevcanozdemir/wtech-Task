using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Core.Service;
using Twitter.Model.Entities;
using Twitter.Web.Models;

namespace Twitter.Web.Controllers
{
    public class HomeController : Controller
    {  
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Follow> _followContext;
        private readonly ITweetService<Tweet> _tweetContext;
        private readonly ICoreService<Like> _likeContext;
        private readonly ICoreService<HashTag> _hashTagContext;
        private IWebHostEnvironment _environment;
        public HomeController( ICoreService<User> context,
            ICoreService<Follow> followContext, ITweetService<Tweet> tweetContext, IWebHostEnvironment environment,
            ICoreService<Like> likeContext, ICoreService<HashTag> _hashTagContext)
        {
           
            _userContext = context;
            _followContext = followContext;
            _tweetContext = tweetContext;
            _environment = environment;
            _likeContext = likeContext;
            _hashTagContext = _hashTagContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
