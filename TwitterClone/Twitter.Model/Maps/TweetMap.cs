using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity.Enums;
using Twitter.Core.Map;
using Twitter.Model.Entities;

namespace Twitter.Model.Maps
{
    public class TweetMap : CoreMap<Tweet>
    {
        public override void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.ToTable("Tweets");
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.Text).HasMaxLength(2000).IsRequired(true);
            builder.HasIndex(x => x.Belong);
            builder.Property(x => x.MediaUrl).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.LikeCount).IsRequired(true);
            builder.Property(x => x.RetweetCount).IsRequired(true);
            builder.Property(x => x.Type).IsRequired(true).HasDefaultValue(TweetType.Tweet);
            builder.Property(x => x.CommentCount).IsRequired(true);
            builder.Property(x => x.TagId).IsRequired(false);
            base.Configure(builder);
        }
    }
}
