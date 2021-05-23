using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;


namespace Twitter.Model.Entities
{
    public class User : CoreEntity
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string About { get; set; }
        public string Location { get; set; }
        public string WebPage { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ProfileBackgroundImage{ get; set; }
        public string ProfileImage { get; set; }
        public string BannerImage { get; set; }
        public string Gender { get; set; }
        public bool IsFollowing { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastIPAddress { get; set; }

        [NotMapped]
        public ICollection<Follow> Followers { get; set; }
        [NotMapped]
        public ICollection<Follow> Following { get; set; }
        [NotMapped]
        public ICollection<Tuple<User, Tweet>> HomePageTweets { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Mention> Mentions { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
       
        [NotMapped]
        public virtual ICollection<Tweet> Comments { get; set; }
       


    }
}
