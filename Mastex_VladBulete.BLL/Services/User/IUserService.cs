using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mastex_BuleteVlad.BLL.Services
{
    public interface IUserService
    {
        List<UserDto> GetUsersByProjectId(int id);
        List<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
    }
}
