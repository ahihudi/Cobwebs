using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cobwebs.Models
{
    public class Project : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Avatar> Avatars { get; set; }
    }
}
