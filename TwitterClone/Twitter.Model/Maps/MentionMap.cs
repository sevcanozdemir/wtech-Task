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
    public class MentionMap : CoreMap<Mention>
    {
        public override void Configure(EntityTypeBuilder<Mention> builder)
        {

            builder.ToTable("Mentions");
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.TweetId).IsRequired(true);
            base.Configure(builder);
        }
    }
}
