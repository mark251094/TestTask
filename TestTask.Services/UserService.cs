using AutoMapper;
using TestTask.Common;
using TestTask.Common.Models;
using TestTask.DataAccess.Entities;
using TestTask.DataAccess.UnitOfWork;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, ILogService logService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logService = logService;
            _mapper = mapper;
        }

        public UserViewModel Create(UserCreateModel request)
        {
            if (_unitOfWork.Users.Any(x => x.Email == request.Email))
                throw Errors.EMAIL_ALREADY_TAKEN;

            if (_unitOfWork.Users.Any(x => x.UserName == request.UserName))
                throw Errors.USER_NAME_ALREADY_TAKEN;

            var user = _mapper.Map<User>(request);

            _unitOfWork.Users.Create(user);

            if (!_unitOfWork.Save())
                throw Errors.NOT_SAVED;

            _logService.Create("User " + user.UserName + " created");

            return _mapper.Map<UserViewModel>(user);
        }

        public void Delete(int id)
        {
            var user = _unitOfWork.Users.Get(x => x.Id == id);

            if (user == null)
                throw Errors.USER_NOT_FOUND;

            _unitOfWork.Users.Delete(id);

            if (!_unitOfWork.Save())
                throw Errors.NOT_SAVED;

            _logService.Create("User " + user.UserName + " deleted");
        }

        public UserViewModel Update(UserUpdateModel request)
        {
            var user = _unitOfWork.Users.Get(x => x.Id == request.Id);

            if (user == null)
                throw Errors.USER_NOT_FOUND;

            if (_unitOfWork.Users.Any(x => x.UserName == request.UserName && x.Id != user.Id))
                throw Errors.USER_NAME_ALREADY_TAKEN;

            if (_unitOfWork.Users.Any(x => x.Email == request.Email && x.Id != user.Id))
                throw Errors.EMAIL_ALREADY_TAKEN;

            var clonedUser = (User)user.Clone();

            user.Email = request.Email;
            user.FullName = request.FullName;
            user.UserName = request.UserName;

            _unitOfWork.Users.Update(user);

            if (!_unitOfWork.Save())
                throw Errors.NOT_SAVED;

            _logService.Create("User " + clonedUser.UserName + " updated", Utils.GetDifference(clonedUser, _mapper.Map<User>(request)));

            return _mapper.Map<UserViewModel>(user);
        }

        public UserListViewModel GetAll()
        {
            var users = _unitOfWork.Users.GetAll();

            return new UserListViewModel { Users = users };
        }
    }
}
