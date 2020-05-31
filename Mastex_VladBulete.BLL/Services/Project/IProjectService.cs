using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mastex_BuleteVlad.BLL.Services
{
    public interface IProjectService
    {
        List<ProjectDto> GetAllProjects();
        ProjectDto GetProjectById(int id);
        List<ProjectDto> GetProjecstByUserId(int uId);
        void DeleteById(int id);
        void EditProject(int id, string title = null, string description = null);
        bool AddProject(string title, string description);
    }
}
