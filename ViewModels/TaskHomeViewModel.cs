using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastex_BuleteVlad.ViewModels
{
    public class TaskHomeViewModel
    {
        public List<TaskViewModel> Tasks { get; set; }
        public List<ProjectViewModel> ProjectFilters { get; set; }
        public int Filter;

        public TaskHomeViewModel()
        {
            Tasks = new List<TaskViewModel>();
            ProjectFilters = new List<ProjectViewModel>();
        }
    }
}
