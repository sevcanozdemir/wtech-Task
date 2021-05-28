using Amazon.AutoScaling.Model;
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
    public class TweetContoller : Controller
    {
        private readonly ITweetService<Tweet> _tweetContext;
        private readonly ICoreService<User> _userContext;
        private readonly ICoreService<Mention> _mentionContext;
        private readonly ICoreService<Notification> _notificationContext;
        private IWebHostEnvironment _environment;


     
        public IActionResult Index()
        {
            return View();
        }
    }
}
