using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Cobwebs.Models
{
    //TODO rename
    public class AvatarTask : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int AvatarID { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual Avatar Avatar { get; set; }
    }
}
