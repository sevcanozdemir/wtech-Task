using Blog.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity.Enums;
using Twitter.Core.Service;
using Twitter.Model.Context;
using Twitter.Model.Entities;

namespace Twitter.Service
{
    public class TweetService<T> : BaseService<T>, ITweetService<T> where T : Tweet
    {
        public TweetService(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public T GetTweet(Expression<Func<T, bool>> exp)
        {
            var tweet = context.Set<T>().Where(x => x.Status != Status.Deleted).Include(x => x.Likes).FirstOrDefault(exp);
            if (tweet == null)
                return null;
            tweet.Comments = GetTweets(x => tweet.ID == x.Belong).OrderByDescending(x => x.CreatedDate).ToList<Tweet>();
            return tweet;
        }

        public T GetTweet(Guid id)
        {
            var tweet = context.Set<T>().Where(x => x.Status != Status.Deleted).Include(x => x.Likes).Where(x => x.ID == id).First();
            if (tweet == null)
                return null;
            tweet.Comments = GetTweets(x => tweet.ID == x.Belong).OrderByDescending(x => x.CreatedDate).ToList<Tweet>();
            return tweet;
        }

        public ICollection<T> GetTweets(Expression<Func<T, bool>> exp)
        {
            ICollection<T> tweets = context.Set<T>().Where(x => x.Status != Status.Deleted).Where(exp).Include(x => x.Likes).Include(x => x.User).ToList();
            if (tweets == null)
                return null;

            return tweets;
        }
    }
}
