using Mastex_BuleteVlad.DAL.Models;
using Mastex_VladBulete.BLL.DTO;
using Mastex_VladBulete.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastex_BuleteVlad.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly Mastex_AppContext _db;

        public TaskService(Mastex_AppContext db)
        {
            _db = db;
        }
        public List<TaskDto> GetllTasks()
        {
            var dbTasks = _db.Tasks.ToList();
            var dtoResults = new List<TaskDto>();
            if (dbTasks?.Count > 0)
            {
                foreach (var item in dbTasks)
                {
                    dtoResults.Add(GetTaskById(item.Id));
                }
            }

            return dtoResults;
        }

        public TaskDto GetTaskById(int id)
        {
            var databaseResult = _db.Tasks.Where(x => x.Id == id).FirstOrDefault();
            var dtoResult = new TaskDto();

            if (databaseResult != null)
            {
                dtoResult = databaseResult.ToDto<Tasks, TaskDto>();
            }

            return dtoResult;
        }

        public List<TaskDto> GetTasksByProjectId(int pId)
        {
            var dbTasks = _db.Tasks.Where(x => x.ProjectId == pId).ToList();
            var dtoResults = new List<TaskDto>();
            if (dbTasks?.Count > 0)
            {
                foreach (var item in dbTasks)
                {
                    dtoResults.Add(GetTaskById(item.Id));
                }
            }

            return dtoResults;
        }
    }
}
