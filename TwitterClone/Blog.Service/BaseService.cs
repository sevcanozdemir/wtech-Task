using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Twitter.Core.Entity;
using Twitter.Core.Entity.Enums;
using Twitter.Core.Service;
using Twitter.Model.Context;

namespace Blog.Service
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        protected readonly DatabaseContext context;

        public BaseService(DatabaseContext context)
        {
            this.context = context;
        }

        public bool Activate(Guid id)
        {
            T activated = GetById(id);
            activated.Status = Status.Active;
            return Update(activated);
        }

        public bool Add(T item)
        {
            try
            {
                context.Set<T>().Add(item);
                return SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Add(List<T> items)
        {
            try
            {
                //rollback if any errors happened
                using (TransactionScope ts = new TransactionScope())
                {
                    context.Set<T>().AddRange(items);
                    ts.Complete();
                    return SaveChanges();
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Any(Expression<Func<T, bool>> exp) => context.Set<T>().Where(x => x.Status != Status.Deleted).Any(exp);

        public ICollection<T> GetActive()
            => context.Set<T>().Where(x => x.Status != Status.Deleted).ToList();

        public ICollection<T> GetAll() => context.Set<T>().Where(x => x.Status != Status.Deleted).ToList();

        public T GetByDefault(Expression<Func<T, bool>> exp)
            => context.Set<T>().Where(x => x.Status != Status.Deleted).FirstOrDefault(exp);

        public T GetById(Guid id) => context.Set<T>().Find(id);

        public ICollection<T> GetDefault(Expression<Func<T, bool>> exp)
            => context.Set<T>().Where(exp).Where(x => x.Status != Status.Deleted).ToList();

        public bool Remove(T item)
        {
            item.Status = Status.Deleted;
            return Update(item);
        }

        public bool RemoveCon(T item)
        {
            context.Set<T>().Remove(item);
            return SaveChanges();
        }

        public bool Remove(Guid id)
        {
            try
            {
                T item = GetById(id);
                item.Status = Status.Deleted;
                return Update(item);
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var collection = GetDefault(exp);
                    int count = 0;
                    foreach (var item in collection)
                    {
                        item.Status = Status.Deleted;
                        bool operationResult = Update(item);
                        if (operationResult) count++;
                    }

                    if (collection.Count == count) ts.Complete();
                    else return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(T item)
        {
            try
            {
                context.Set<T>().Update(item);
                return SaveChanges();
            }
            catch
            {
                return false;
            }
        }
    
    }
}
