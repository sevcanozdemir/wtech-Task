using Amazon.DeviceFarm.Model;
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
        private readonly ITweetService<TweetContoller> _tweetContext;
        private readonly ICoreService<Follow> _followContext;
        private IWebHostEnvironment _env;

        public ProfileController(ICoreService<User> usercontext, ICoreService<Follow> followContext,
            ITweetService<TweetContoller> tweetContext, IWebHostEnvironment env)
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
        public IActionResult DeleteTweet(Guid id)
        {
            var username = User.FindFirst("Username").Value;
            _tweetContext.Remove(id);
            return Redirect("/" + username);
        }
        public IActionResult Followers(string username)
        {
            User user = _userContext.GetByDefault(x => x.Username == username);
            Guid userId = user.ID;
            var query = from u in _userContext.GetAll()
                        join f in _followContext.GetDefault(x => x.FollowingId == userId)
                            on u.ID equals f.FollowerId
                        orderby f.CreatedDate descending
                        select u;
            List<User> res = query.ToList();
            return View(res);
        }

        public IActionResult Following(string username)
        {
            User user = _userContext.GetByDefault(x => x.Username == username);
            Guid userId = user.ID;
            var query = from u in _userContext.GetAll()
                        join f in _followContext.GetDefault(x => x.FollowerId == userId)
                            on u.ID equals f.FollowingId
                        orderby f.CreatedDate descending
                        select u;
            List<User> result = query.ToList();
            return View(result);
        }
        public IActionResult Tweets(string username)
        {
            User user = _userContext.GetByDefault(x => x.Username == username);
            user.Tweets = _tweetContext.GetTweets(x => x.UserId == user.ID && x.Type == TweetType.Tweet)
                .OrderByDescending(x => x.CreatedDate).ToList();

            return View(user);
        }
        [HttpPost]
        public IActionResult Follow(string id, string username, string action)
        {
            if (action.Equals("follow"))
            {
                Follow follow = new Follow();
                follow.FollowerId = Guid.Parse(User.FindFirst("ID").Value);
                follow.FollowingId = Guid.Parse(id);
                _followContext.Add(follow);
            }
            else
            {
                Guid followerId = Guid.Parse(User.FindFirst("ID").Value);
                Guid followingId = Guid.Parse(id);
                Follow follow = _followContext.GetByDefault(x => x.FollowerId == followerId && x.FollowingId == followingId);
                _followContext.RemoveCon(follow);
            }
            return Redirect("/" + username);


        }
        public IActionResult UserProfile(string username)
        {
            if (username == null)
            {
                Guid id = Guid.Parse(User.FindFirst("ID").Value);
                var user = _userContext.GetById(id);
                user.Followers = _followContext.GetDefault(x => x.FollowingId == user.ID).OrderByDescending(y => y.CreatedDate).ToList();
                user.Following = _followContext.GetDefault(x => x.FollowerId == user.ID).OrderByDescending(y => y.CreatedDate).ToList();
                user.Tweets = _tweetContext.GetTweets(x => x.UserId == user.ID && x.Type == TweetType.Tweet).OrderByDescending(y => y.CreatedDate).ToList();

                return View(user);
            }
            else
            {
                username = username.Trim('@');
                if (User.FindFirst("Username").Value == username)
                {
                    return RedirectToAction("Index", "Profile");
                }

                var user = _userContext.GetByDefault(x => x.Username == username);
                if (user == null)
                {
                    TempData["NotFoundName"] = "@" + username;
                    return RedirectToAction("NameNotFound", "Home");
                }

                user.Followers = _followContext.GetDefault(x => x.FollowingId == user.ID).OrderByDescending(y => y.CreatedDate).ToList();
                user.Following = _followContext.GetDefault(x => x.FollowerId == user.ID).OrderByDescending(y => y.CreatedDate).ToList();
                user.Tweets = _tweetContext.GetTweets(x => x.UserId == user.ID && x.Type == TweetType.Tweet).OrderByDescending(y => y.CreatedDate).ToList();

                return View(user);
            }


        }
    }
}
