using BootcampFinalProject.Base.Abstract;
using BootcampFinalProject.Entities.Model;
using BootcampFinalProject.Models;

namespace BootcampFinalProject.Service
{
    public interface IUserService : IBaseService<UserDto,User>
    {
        public void Register(UserDto model);
        public UserDto GetUserByEmail(string email);
    }
}
