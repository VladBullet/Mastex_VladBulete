using Mastex_BuleteVlad.DAL.Models;
using Mastex_VladBulete.BLL.DTO;
using Mastex_VladBulete.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastex_BuleteVlad.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly Mastex_AppContext _db;
        private readonly IUserService _userService;
        private readonly ISharedService _sharedService;

        public ProjectService(Mastex_AppContext context, IUserService userService, ISharedService sharedService)
        {
            _db = context;
            _userService = userService;
            _sharedService = sharedService;
        }
        public List<ProjectDto> GetAllProjects()
        {
            var databaseResult = _db.Projects.Where(x => !x.Deleted).ToList();
            var dtoResutls = new List<ProjectDto>();
            foreach (var item in databaseResult)
            {
                var aux = item.ToDto<Projects, ProjectDto>();
                if (aux != null)
                {
                    var assignedUsers = _userService.GetUsersByProjectId(item.Id);
                    var tasks = _sharedService.GetTasksByProjectId(item.Id);
                    aux.AssingedUsers = assignedUsers;
                    aux.Tasks = tasks;
                    dtoResutls.Add(aux);
                }
            }
            return dtoResutls;
        }
        public ProjectDto GetProjectById(int id)
        {
            var databaseResult = _db.Projects.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
            var dtoResult = new ProjectDto();

            if (databaseResult != null)
            {
                dtoResult = databaseResult.ToDto<Projects, ProjectDto>();
                if (dtoResult != null)
                {
                    var assignedUsers = _userService.GetUsersByProjectId(dtoResult.Id);
                    var tasks = _sharedService.GetTasksByProjectId(dtoResult.Id);
                    dtoResult.AssingedUsers = assignedUsers;
                    dtoResult.Tasks = tasks;
                }
            }

            return dtoResult;
        }
        public List<ProjectDto> GetProjecstByUserId(int uId)
        {
            var projectIds = _db.ProjectUsers.Where(x => x.UserId == uId).Select(x => x.ProjectId).ToList();
            var dtoResults = new List<ProjectDto>();
            if (projectIds?.Count > 0)
            {
                foreach (var id in projectIds)
                {
                    dtoResults.Add(GetProjectById(id));
                }
            }

            return dtoResults;
        }
        public void DeleteById(int id)
        {
            var databaseResult = _db.Projects.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
            if (databaseResult != null)
            {
                databaseResult.Deleted = true;
                _db.SaveChanges();
            }
        }
        public void EditProject(int id, string title = null, string description = null)
        {
            // if title and description are both null ->  exit
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(description))
            {
                return;
            }
            var databaseResult = _db.Projects.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
            if (!string.IsNullOrEmpty(title))
            {
                databaseResult.Title = title;
            }
            if (!string.IsNullOrEmpty(description))
            {
                databaseResult.Description = description;
            }
            _db.SaveChanges();
        }
        public bool AddProject(string title, string description)
        {
            // if either of title or description is null - > exit
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                return false;
            }
            _db.Projects.Add(new Projects { Title = title, Description = description, Deleted = false });

            _db.SaveChanges();
            return true;
        }
       
    }
}
