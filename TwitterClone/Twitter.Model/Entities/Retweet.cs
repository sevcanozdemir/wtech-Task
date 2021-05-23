using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.Model.Entities
{
    public class Retweet : CoreEntity
    {
        public int? UserID { get; set; }
        public virtual User User { get; set; }
        public int? TweetID { get; set; }
        public virtual Tweet Tweet { get; set; }
    }
}
