using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entity;

namespace Twitter.Model.Entities
{
    public class Message : CoreEntity
    {
        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }
        public Guid ChatId { get; set; }

        public bool User1Sent { get; set; }
        public string Content { get; set; }

    }
}
