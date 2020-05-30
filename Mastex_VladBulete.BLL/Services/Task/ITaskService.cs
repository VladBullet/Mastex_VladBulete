using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mastex_BuleteVlad.BLL.Services
{
    public interface ITaskService
    {
        List<TaskDto> GetllTasks();
        List<TaskDto> GetTasksByProjectId(int pId);
        TaskDto GetTaskById(int id);

       
    }
}
