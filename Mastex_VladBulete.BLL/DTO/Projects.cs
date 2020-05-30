using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Mastex_VladBulete.BLL.DTO
{
    public class ProjectDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public List<UserDTO> AssingedUsers { get; set; }
        public ProjectDto()
        {
            AssingedUsers = new List<UserDTO>();
        }
    }
}
