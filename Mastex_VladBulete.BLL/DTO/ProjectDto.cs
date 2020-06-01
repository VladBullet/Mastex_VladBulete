using Mastex_BuleteVlad.BLL.DTO;
using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastex_VladBulete.BLL.DTO
{
    public class ProjectDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public StatusEnum Status
        {
            get
            {
                var result = StatusEnum.Created;
                var tasksStatuses = Tasks.Select(x => x.Status);
                if (tasksStatuses.All(x => x == "Done"))
                {
                    result = StatusEnum.Done;
                    return result;
                }
                if (tasksStatuses.Any(x => x == "Researching"))
                {
                    result = StatusEnum.Researching;
                }
                if (tasksStatuses.Any(x => x == "InProgress"))
                {
                    result = StatusEnum.InProgress;
                }
                return result;
            }
        }
        public List<UserDto> AssingedUsers { get; set; }
        public List<TaskDto> Tasks { get; set; }
        public ProjectDto()
        {
            AssingedUsers = new List<UserDto>();
            Tasks = new List<TaskDto>();
        }
    }
}
