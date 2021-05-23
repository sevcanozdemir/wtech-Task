using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;
using Twitter.Model.Entities;
using Twitter.Model.Maps;

namespace Twitter.Model.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Mention> Mentions { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Retweet> Retweets { get; set; }
        public DbSet<HashTag> HashTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

         
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new FollowMap());
            modelBuilder.ApplyConfiguration(new ChatMap());
            modelBuilder.ApplyConfiguration(new MessageMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());
            modelBuilder.ApplyConfiguration(new LikeMap());
            modelBuilder.ApplyConfiguration(new MentionMap());
            modelBuilder.ApplyConfiguration(new TweetMap());
            modelBuilder.ApplyConfiguration(new RetweetMap());
            modelBuilder.ApplyConfiguration(new NotificationMap());
            modelBuilder.ApplyConfiguration(new HashTagMap());


            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified
                || x.State == EntityState.Added).ToList();


            string computerName = Environment.MachineName;
            string ipAddress = "127.0.0.1";
            DateTime date = DateTime.Now;

            foreach (var item in modifiedEntities)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedComputerName = computerName;
                            entity.CreatedIP = ipAddress;
                            entity.CreatedDate = date;
                            break;

                        case EntityState.Modified:
                            entity.ModifiedComputerName = computerName;
                            entity.ModifiedIP = ipAddress;
                            entity.ModifiedDate = date;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

    }
}
