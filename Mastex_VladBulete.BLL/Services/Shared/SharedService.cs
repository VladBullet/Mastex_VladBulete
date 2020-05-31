using Mastex_BuleteVlad.DAL.Models;
using Mastex_VladBulete.BLL.DTO;
using Mastex_VladBulete.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastex_BuleteVlad.BLL.Services
{
    public class SharedService : ISharedService
    {

        protected readonly Mastex_AppContext _db;
       
        public SharedService(Mastex_AppContext db)
        {
            _db = db;
        }
        public List<TaskDto> GetTasksByProjectId(int pId)
        {
            var dbTasks = _db.Tasks.Where(x => x.ProjectId == pId && !x.Deleted).ToList();
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
            var databaseResult = _db.Tasks.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
            var dtoResult = new TaskDto();

            if (databaseResult != null)
            {
                dtoResult = databaseResult.ToDto<Tasks, TaskDto>();
            }

            return dtoResult;
        }
        public void AssignUserToProject(int userId, int ProjectId)
        {
            _db.ProjectUsers.Add(new ProjectUsers { ProjectId = ProjectId, UserId = userId });
            _db.SaveChanges();
        }
    }
}
