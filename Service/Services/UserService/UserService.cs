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
        Response response = new Response();
        public async Task<string> Login(AuthorizationDTO dto)
        {
            var user = await _uRepository.GetUserbyEmail(dto.EmailAddress);
            try
            {
                if (user == null)
                {
                    return response.ToLog("400", "This User does not exists!");
                }
                if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                {
                    var msq = response.ToLog("400", "Invalid credentials");
                    return msq;
                }
                var tokenJWT = await _uRepository.JSONToken(user);
                return tokenJWT;
            }
            catch (Exception ex)
            {
                return response.Log(null, ex.Message.ToString());
            }
        }

        public async Task<string> RegisterUser(RegisterDTO dto)
        {
            try
            {
                if (dto.Password != dto.RepeatPassword)
                    return response.ToLog("400", "The password doesn't match with repeated one!");
                if (!dto.EmailAddress.Contains("@team.alif.tj"))
                    return response.ToLog("400", "Error while adding a user, please enter a valid email address!");
                else
                    await _uRepository.InsertUser(dto); return "Success! User is registered!";
            }
            catch (Exception ex)
            {
               return response.ToLog(null, ex.Message.ToString());
            }
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
