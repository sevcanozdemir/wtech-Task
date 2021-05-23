using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Map;
using Twitter.Model.Entities;

namespace Twitter.Model.Maps
{
    public class LikeMap : CoreMap<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {

            builder.ToTable("Likes");
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.TweetId).IsRequired(true);

            base.Configure(builder);
        }
    }
}
