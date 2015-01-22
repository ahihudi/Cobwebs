using System.ComponentModel.DataAnnotations.Schema;

namespace Cobwebs.Models
{
    public class AutoAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AlertBotID { get; set; }
        public string Schedule { get; set; }

        public virtual AlertBot AlertBot { get; set; }
        public virtual Avatar Avatar { get; set; }
    }
}
