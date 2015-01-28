using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cobwebs.Models
{
    public class Avatar : BaseEntity
    {
        //Database Rows
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public AvatarType AvatarType { get; set; }
        public Gender Gender { get; set; }

        //Additional Properties
        public string FullName { 
            get { return FirstName + " " + LastName; } 
        }

        //Navigation Propertis
        public virtual Project Project { get; set; }
        public virtual ICollection<AvatarAccount> Accounts { get; set; }
        public virtual ICollection<AutoAccount> AutoAccounts { get; set; }
        public virtual ICollection<AvatarNote> Notes { get; set; }
        public virtual ICollection<AvatarTask> CalendarTasks { get; set; }

        public virtual ICollection<Target> Targets { get; set; }
        /*
         * The following properties were added to support many to many relationship between avatars to themselves
         * Should check if relations are realy many2many or can be one2many
         * */
        public virtual ICollection<Avatar> Followers { get; set; }
        public virtual ICollection<Avatar> Following { get; set; }

    }

    public enum AvatarType
    {
        Main, Sub, ProjectDefault
    }

    public enum Gender
    {
        Male, Female
    }
}