using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.Model.Entities
{
    public class HashTag : CoreEntity
    {
        public string Name { get; set; }

        public ICollection<Tweet> Tweets { get; set; }
        public ICollection<Retweet> Retweets { get; set; }
    }
}
