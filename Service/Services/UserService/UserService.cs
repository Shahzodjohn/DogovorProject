using Entity;
using Entity.DataTransfer_s;
using Entity.DataTransfer_s.Authorization;
using Entity.Entities;
using Entity.ResponseMessage;
using Interface.Interfaces;
using Repository.Interfaces;
using Repository.Interfaces.DepartmentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _uRepository;
        private readonly IDepartmentRepository _dRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IDepartmentRepository dRepository, IRoleRepository roleRepository)
        {
            _uRepository = userRepository;
            _dRepository = dRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Response> Login(AuthorizationDTO dto)
        {
            var user = await _uRepository.GetUserbyEmail(dto.EmailAddress);
            if (user == null)
                return new Response { Status = "Error", Message = "This User does not exists!" };
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return new Response { Status = "400", Message = "Invalid credentials" };
            }
            var tokenJWT = await _uRepository.JSONToken(user);
            return new Response { Status = "200", Message = tokenJWT };
        }

        public async Task<Response> RegisterUser(RegisterDTO dto)
        {
            if (dto.Password != dto.RepeatPassword)
                return new Response{ Status = "400", Message = "The password doesn't match with repeated one!" };
            if (!dto.EmailAddress.Contains("@team.alif.tj"))
                return new Response { Status = "400", Message = "Error while adding a user, Please enter a valid Email Address!" };
            else
                await _uRepository.InsertUser(dto); return new Response { Status = "200", Message = "Success! User is registered!" };
        }

        public async Task<UserDepartmentDTO> UsersInformation(ClaimsIdentity claim)
        {
            var user = await _uRepository.GetUserbyEmail(claim.Name);
            var Department = await _dRepository.GetDepartmentbyId(user.DepartmentId);
            var role = await _roleRepository.GetRoleById(user.RoleId);
            var userInfo = new UserDepartmentDTO
            {
                UserId = user.Id,
                EmailAddress = user.EmailAddress,
                DepartmentId = Department.Id,
                DepartmentName = Department.DepartmentName,
                RoleId = role.Id,
                RoleName = role.RoleName,
                Password = "you do not have to see the password"
            };
            return userInfo;
        }
    }
}
