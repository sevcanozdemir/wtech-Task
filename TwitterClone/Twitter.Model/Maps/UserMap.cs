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
    public class UserMap : CoreMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users");
            builder.HasIndex(x => x.Username).IsUnique(true);
            builder.Property(x => x.Username).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Fullname).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.About).HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.Location).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.WebPage).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.BirthDate).IsRequired(false);
            builder.Property(x => x.BannerImage).HasMaxLength(250).IsRequired(false);
            builder.Property(x => x.LastLogin).IsRequired(false);
            builder.Property(x => x.LastIPAddress).HasMaxLength(15).IsRequired(false);
            builder.Property(x => x.ProfileBackgroundImage).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.ProfileImage).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.Gender).HasMaxLength(10).IsRequired(false);


            base.Configure(builder);
        }
    }
}
