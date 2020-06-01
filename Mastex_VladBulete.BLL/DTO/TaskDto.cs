using Mastex_BuleteVlad.BLL.DTO;
using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Mastex_VladBulete.BLL.DTO
{
    public class TaskDto:IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedUserId { get; set; }
        public string Status { get; set; }
       
    }
}
