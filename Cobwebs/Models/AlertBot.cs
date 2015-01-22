using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cobwebs.Models
{
    public class AlertBot
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AutoAccount> AutoAccounts { get; set; }
    }
}
