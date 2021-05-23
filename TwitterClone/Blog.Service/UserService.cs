using Blog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Service;
using Twitter.Model.Context;
using Twitter.Model.Entities;

namespace Twitter.Service
{
    public class UserService<T> : BaseService<T>, IUserService<T> where T : User
    {
        public UserService(DatabaseContext context) : base(context)
        {
        }
    }
}
