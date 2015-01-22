using System.ComponentModel.DataAnnotations.Schema;

namespace Cobwebs.Models
{
    public class AvatarNote : BaseEntity
    {
        //Database Rows
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int AvatarID { get; set; }
        public string Content { get; set; }


        //Naviagation Properties
        public virtual Avatar Avatar { get; set; }
    }
}
