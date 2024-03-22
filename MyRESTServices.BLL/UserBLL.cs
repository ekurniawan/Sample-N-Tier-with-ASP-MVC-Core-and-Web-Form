using AutoMapper;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;
using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain.Models;

namespace MyRESTServices.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserData _userData;
        private readonly IMapper _mapper;

        public UserBLL(IUserData userData, IMapper mapper)
        {
            _userData = userData;
            _mapper = mapper;
        }

        public Task<Task> ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Delete(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _userData.GetAll();
            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return userDTOs;
        }

        public Task<IEnumerable<UserDTO>> GetAllWithRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByUsername(string username)
        {
            var user = _userData.GetByUsername(username);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> GetUserWithRoles(string username)
        {
            var user = await _userData.GetUserWithRoles(username);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<Task> Insert(UserCreateDTO entity)
        {
            try
            {
                var createUser = _mapper.Map<User>(entity);
                await _userData.Insert(createUser);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserDTO> Login(LoginDTO loginDTO)
        {
            var user = await _userData.Login(loginDTO.Username, loginDTO.Password);
            if (user == null)
            {
                throw new ArgumentException("Invalid username or password");
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
