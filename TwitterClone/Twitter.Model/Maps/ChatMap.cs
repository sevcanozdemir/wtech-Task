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
    public class ChatMap : CoreMap<Chat>
    {
        public override void Configure(EntityTypeBuilder<Chat> builder)
        {

            builder.ToTable("Chats");
            builder.HasIndex(x => x.User1Id).IsUnique(false);
            builder.HasIndex(x => x.User2Id).IsUnique(false);
            builder.Property(x => x.User1Id).HasMaxLength(150).IsRequired(true);
            builder.Property(x => x.User2Id).HasMaxLength(150).IsRequired(true);
            base.Configure(builder);
        }
    }
}
