using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.Model.Entities
{
    public class Follow: CoreEntity
    {
        public Guid FollowerId { get; set; }

        public Guid FollowingId { get; set; }
    }
}
