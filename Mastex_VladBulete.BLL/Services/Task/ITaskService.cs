using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mastex_BuleteVlad.BLL.Services
{
    public interface ITaskService
    {
        List<TaskDto> GetAllTasks();
        TaskDto GetTaskById(int id);
        void DeleteById(int id);
        void EditTask(int id, string title = null, string description = null, string status = null);
        bool AddTask(int pId, string title, string description);
        void AssignUserToTask(int tId, int uId);
    }
}
