
using System.Collections.Generic;
using Cobwebs.Models;

namespace Cobwebs.ViewModels
{
    public class ProjectsIndexData
    {
        public int? ProjectID { get; set; }
        public int? AvatarID { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Avatar> Avatars { get; set; }
        public IEnumerable<AvatarNote> Notes { get; set; }

        public IEnumerable<AvatarTask> Task { get; set; }

    }
}