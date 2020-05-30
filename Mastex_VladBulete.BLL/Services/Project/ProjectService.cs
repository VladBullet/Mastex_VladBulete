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

        public ProjectService(Mastex_AppContext context, UserService userService)
        {
            _db = context;
            _userService = userService;
        }
        public List<ProjectDto> GetAllProjects()
        {
            var databaseResult = _db.Projects.ToList();
            var dtoResutls = new List<ProjectDto>();
            foreach (var item in databaseResult)
            {
                var aux = item.ToDto<Projects, ProjectDto>();
                dtoResutls.Add(aux);
            }
            return dtoResutls;
        }
        public ProjectDto GetProjectById(int id)
        {
            var databaseResult = _db.Projects.Where(x => x.Id == id).FirstOrDefault();
            var dtoResult = new ProjectDto();

            if (databaseResult !=null)
            {
                dtoResult = databaseResult.ToDto<Projects, ProjectDto>();
                var assignedUsers = _userService.GetUsersByProjectId(dtoResult.Id);
                dtoResult.AssingedUsers = assignedUsers;
            }
           
            return dtoResult;
        }
        public List<ProjectDto> GetProjecstByUserId(int uId)
        {
            var projectIds = _db.ProjectUsers.Where(x => x.UserId == uId).Select(x => x.ProjectId).ToList();
            var dtoResults = new List<ProjectDto>();
            foreach (var id in projectIds)
            {
                dtoResults.Add(GetProjectById(id));
            }
            return dtoResults;

        }
    }
}
