using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        bool Add(T item);
        bool Add(List<T> items);
        bool Update(T item);
        bool Remove(T item);
        bool RemoveCon(T item);
        bool Remove(Guid id);
        bool RemoveAll(Expression<Func<T, bool>> exp);
        T GetById(Guid id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        ICollection<T> GetActive();
        ICollection<T> GetDefault(Expression<Func<T, bool>> exp);
        ICollection<T> GetAll();
        bool Activate(Guid id);
        bool Any(Expression<Func<T, bool>> exp);
        bool SaveChanges();
    }
}
