using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.Core.Service
{
    public interface IUserService<T> : ICoreService<T> where T : CoreEntity
    {
    }
}
