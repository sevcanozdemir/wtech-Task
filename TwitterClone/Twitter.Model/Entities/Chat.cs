using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.Model.Entities
{
    public class Chat :CoreEntity
    {
        public Guid User1Id { get; set; }
        public Guid User2Id { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
