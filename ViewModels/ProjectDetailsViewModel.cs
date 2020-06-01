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
        public List<TaskViewModel> Tasks { get; set; }
        public ProjectDetailsViewModel()
        {
            AssignedUsers = new List<UserViewModel>();
            Tasks = new List<TaskViewModel>();
        }
        public ProjectDetailsViewModel(ProjectViewModel proj)
        {
            Project = proj;
        }
    }
}
