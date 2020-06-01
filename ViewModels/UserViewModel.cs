using Mastex_VladBulete.BLL.DTO;

namespace Mastex_BuleteVlad.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public UserViewModel(UserDto usr)
        {
            Id = usr.Id;
            Name = usr.Name;
            Role = usr.Role;
        }
    }
}