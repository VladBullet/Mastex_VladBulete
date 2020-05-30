using Mastex_BuleteVlad.DAL.Models;
using Mastex_VladBulete.BLL.DTO;
using Mastex_VladBulete.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastex_BuleteVlad.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly Mastex_AppContext _db;
        public UserService(Mastex_AppContext db)
        {
            _db = db;
        }
        public List<UserDto> GetUsersByProjectId(int uId)
        {
            var usersIds = _db.ProjectUsers.Where(x => x.ProjectId == uId).Select(x => x.UserId).ToList();
            var dtoResults = new List<UserDto>();
            foreach (var id in usersIds)
            {
                dtoResults.Add(GetUserById(id));
            }
            return dtoResults;
        }
        public UserDto GetUserById(int id)
        {
            var databaseResult = _db.Users.Where(x => x.Id == id).FirstOrDefault();
            var dtoResult = new UserDto();

            if (databaseResult != null)
            {
                dtoResult = databaseResult.ToDto<Users, UserDto>();
            }

            return dtoResult;
        }

        public List<UserDto> GetAllUsers()
        {
            var users = _db.Users.ToList();
            var dtoResults = new List<UserDto>();
            foreach (var item in users)
            {
                dtoResults.Add(GetUserById(item.Id));
            }
            return dtoResults;
        }
    }
}
