using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastex_BuleteVlad.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectViewModel Project { get; set; }
        public List<UserViewModel> AssignedUsers { get; set; }
        public ProjectDetailsViewModel()
        {
            AssignedUsers = new List<UserViewModel>();
        }
        public ProjectDetailsViewModel(ProjectViewModel proj)
        {
            Project = proj;
        }
    }
}
