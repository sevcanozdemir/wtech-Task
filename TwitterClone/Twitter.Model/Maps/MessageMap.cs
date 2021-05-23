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
    public class MessageMap : CoreMap<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {

            builder.ToTable("Messages");
            builder.Property(x => x.Content).HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.User1Sent).IsRequired(true);
            builder.Property(x => x.ChatId).IsRequired(true);

            base.Configure(builder);
        }
    }
}
