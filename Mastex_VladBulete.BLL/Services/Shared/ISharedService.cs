using Mastex_VladBulete.BLL.DTO;
using System.Collections.Generic;

namespace Mastex_BuleteVlad.BLL.Services
{
    public interface ISharedService
    {
        List<TaskDto> GetTasksByProjectId(int pId);
        TaskDto GetTaskById(int id);
        void AssignUserToProject(int userId, int ProjectId);

    }
}