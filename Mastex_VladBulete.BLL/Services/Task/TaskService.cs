using Mastex_BuleteVlad.BLL.DTO;
using Mastex_BuleteVlad.DAL.Models;
using Mastex_VladBulete.BLL.DTO;
using Mastex_VladBulete.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastex_BuleteVlad.BLL.Services
{
    public class TaskService : SharedService, ITaskService, ISharedService
    {
        public TaskService(Mastex_AppContext db) : base(db) { }
        public List<TaskDto> GetAllTasks()
        {
            var dbTasks = _db.Tasks.Where(x => !x.Deleted).ToList();
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
        public void DeleteById(int id)
        {
            var databaseResult = _db.Tasks.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
            if (databaseResult != null)
            {
                databaseResult.Deleted = true;
                _db.SaveChanges();
            }

        }
        public void EditTask(int id, string title = null, string description = null, string status = null)
        {
            // if title, description and status are all null ->  exit
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(status))
            {
                return;
            }
            var databaseResult = _db.Tasks.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
            if (!string.IsNullOrEmpty(title))
            {
                databaseResult.Title = title;
            }
            if (!string.IsNullOrEmpty(description))
            {
                databaseResult.Description = description;
            }
            if (!string.IsNullOrEmpty(status))
            {
                databaseResult.Status = status;
            }
            _db.SaveChanges();
        }
        public bool AddTask(int pId, string title, string description)
        {
            // if either of title or description is null - > exit
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                return false;
            }
            _db.Tasks.Add(new Tasks { Title = title, Description = description, Status = StatusEnum.Created.Value, ProjectId = pId, AssignedUserId = null, Deleted = false });
            _db.SaveChanges();
            return true;
        }
        public void AssignUserToTask(int tId, int uId)
        {
            var dbResult = _db.Tasks.Where(x => x.Id == tId && !x.Deleted).FirstOrDefault();
            if (dbResult != null)
            {
                AssignUserToProject(dbResult.ProjectId, uId);
                dbResult.AssignedUserId = uId;
                _db.SaveChanges();
            }

        }
    }
}
