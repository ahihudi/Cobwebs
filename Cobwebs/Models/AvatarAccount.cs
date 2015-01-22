using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cobwebs.Models
{
    public class AvatarAccount : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int AvatarID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        
        public virtual ICollection<Avatar> Avatars { get; set; }
    }
}
