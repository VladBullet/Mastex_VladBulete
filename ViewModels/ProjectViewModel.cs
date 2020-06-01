using Mastex_BuleteVlad.BLL.DTO;
using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastex_BuleteVlad.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel() { }
        public ProjectViewModel(int id, string title, string description, string status, string color)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = new StatusEnum(status);
            Color = color;
        }
        public ProjectViewModel(ProjectDto proj)
        {
            Id = proj.Id;
            Title = proj.Title;
            Description = proj.Description;
            Status = proj.Status;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        private string _color { get; set; }
        public string Color
        {
            get
            {
                _color = "primary";
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
    }
}
