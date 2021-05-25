using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter.Core.Entity.Enums;
using Twitter.Core.Service;
using Twitter.Model.Entities;

namespace Twitter.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {


        private readonly ICoreService<User> _userContext;
        private readonly ITweetService<Tweet> _tweetContext;
        private readonly ICoreService<Follow> _followContext;
        private IWebHostEnvironment _env;

        public ProfileController(ICoreService<User> usercontext, ICoreService<Follow> followContext,
            ITweetService<Tweet> tweetContext, IWebHostEnvironment env)
        {
            _userContext = usercontext;
            _tweetContext = tweetContext;
            _followContext = followContext;
            _env = env;
        }

        public IActionResult Index()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            var user = _userContext.GetById(id);
            user.Followers = _followContext.GetDefault(x => x.FollowingId == user.ID).OrderByDescending(y => y.CreatedDate).ToList();
            user.Following = _followContext.GetDefault(x => x.FollowerId == user.ID).OrderByDescending(y => y.CreatedDate).ToList();
            user.Tweets = _tweetContext.GetTweets(x => x.UserId == user.ID && x.Type == TweetType.Tweet).OrderByDescending(y => y.CreatedDate).ToList();

            return View(user);
        }
        public IActionResult Edit()
        {
            Guid id = Guid.Parse(User.FindFirst("ID").Value);
            return View(_userContext.GetById(id));
        }

    }
}
