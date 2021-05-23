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
    public class HashTagMap : CoreMap<HashTag>
    {
        public override void Configure(EntityTypeBuilder<HashTag> builder)
        {

            builder.ToTable("HashTags");
            builder.HasIndex(x => x.Name).IsUnique(true);

            base.Configure(builder);
        }
    }
}
