using System.Collections.Generic;

namespace Cobwebs.Models
{
    public class Target : BaseEntity
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Name { get; set; }
        //public string LastName { get; set; }
        //public string FirstName { get; set; }
        
        ////Additional Properties
        //public string FullName { get { return FirstName + " " + LastName;  } }

        //Navigation Properties
        public virtual ICollection<Avatar> Avatars { get; set; }
    }
}
