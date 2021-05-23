using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.Core.Service
{
    public interface ITweetService<T> : ICoreService<T> where T : CoreEntity
    {
        public ICollection<T> GetTweets(Expression<Func<T, bool>> exp);
        public T GetTweet(Expression<Func<T, bool>> exp);
        public T GetTweet(Guid id);
    }
}
