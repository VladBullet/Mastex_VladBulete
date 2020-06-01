using Mastex_BuleteVlad.BLL.DTO;
using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastex_BuleteVlad.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedUserId { get; set; }
        public StatusEnum Status { get; set; }
        private string _color = "primary";
        public string Color
        {
            get
            {
                if (Status.Value == StatusEnum.Done.Value)
                {
                    _color = "success";
                }
                else if (Status.Value == StatusEnum.Created.Value)
                {
                    _color = "dark";
                }
                else if (Status.Value == StatusEnum.Researching.Value)
                {
                    _color = "info";
                }
                else if (Status.Value == StatusEnum.InProgress.Value)
                {
                    _color = "warning";
                }
                return _color;
            }
            set { _color = value; }
        }
        public TaskViewModel(){}
        public TaskViewModel( TaskDto task)
        {
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
            ProjectId = task.ProjectId;
            AssignedUserId = task.AssignedUserId;
            Status = new StatusEnum(task.Status);
        }
    }
}
