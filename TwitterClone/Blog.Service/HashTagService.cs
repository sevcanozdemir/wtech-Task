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
    public class HashTagService<T> : BaseService<T>, IHashTagService<T> where T : HashTag
    {
        private readonly ITweetService<Tweet> _tweetContext;

        public HashTagService(DatabaseContext dbContext, ITweetService<Tweet> tweetContext) : base(dbContext)
        {
            _tweetContext = tweetContext;
        }

        public ICollection<T> GetAllTags()
        {
            var tags = context.Set<T>().Where(x => x.Status != Status.Deleted)
                .Include(x => x.Tweets.Where(y => y.Status != Status.Deleted)).ToList<T>();
            return tags;
        }

        public T GetTag(Expression<Func<T, bool>> exp)
        {
            var tag = context.Set<T>().FirstOrDefault(exp);
            tag.Tweets = _tweetContext.GetTweets(x => x.TagId == tag.ID);
            return tag;
        }

        public List<Tuple<string, int>> GetTrends()
        {
            List<Tuple<string, int>> Trends = new List<Tuple<string, int>>();
            var tags = GetAllTags();
            foreach (var tag in tags)
            {
                Trends.Add(Tuple.Create(tag.Name, tag.Tweets.Count));
            }
            Trends.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            return Trends;
        }

    }
}
