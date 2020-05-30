using Mastex_VladBulete.BLL.DTO;
using System;
using System.Collections.Generic;

namespace Mastex_VladBulete.BLL.DTO
{
    public class UserDTO:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public bool Deleted { get; set; }
    }
}
