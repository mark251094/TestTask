using TestTask.Common.Models;

namespace TestTask.Services
{
    public interface IUserService
    {
        UserViewModel Create(UserCreateModel request);
        void Delete(int id);
        UserViewModel Update(UserUpdateModel request);
        UserListViewModel GetAll();
    }
}
