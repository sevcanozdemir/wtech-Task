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
    public class NotificationMap : CoreMap<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {

            builder.ToTable("Notifications");
            builder.Property(x => x.Content).HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.IsActive).IsRequired(true);
           

            base.Configure(builder);
        }
    }
}
