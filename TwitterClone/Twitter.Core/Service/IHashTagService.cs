using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.Core.Service
{
    public interface IHashTagService<T> : ICoreService<T> where T : CoreEntity
    {
        public List<Tuple<string, int>> GetTrends();
        public ICollection<T> GetAllTags();
        public T GetTag(Expression<Func<T, bool>> exp);
    }
}
