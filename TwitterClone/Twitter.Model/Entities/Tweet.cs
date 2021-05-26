using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;
using Twitter.Core.Entity.Enums;

namespace Twitter.Model.Entities
{
    public class Tweet : CoreEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("TagId")]
        public HashTag Tag { get; set; }
        public Guid? TagId { get; set; }

        public Guid? Belong{ get; set; }
        [NotMapped]
        public Guid? Parent { get; set; }
        public int LikeCount { get; set; }
        public TweetType Type { get; set; }
        public Guid? RetweetId { get; set; }
        public Tweet Retweet { get; set; }
        public int RetweetCount { get; set; }
        public int CommentCount { get; set; }

        public string MediaUrl { get; set; }
        public string Text { get; set; }

        [NotMapped]
        public virtual ICollection<Tweet> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Mention> Mentions { get; set; }
        public virtual ICollection<Retweet> Retweets { get; set; }
    }
}
