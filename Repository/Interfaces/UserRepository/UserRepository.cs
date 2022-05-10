using ConnectionProvider;
using Entity;
using Entity.DataTransfer_s;
using Entity.DataTransfer_s.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using Entity.Entities;

namespace Interface.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> GetUserbyEmail(string email)
        {
            var findUser = await _context.users.FirstOrDefaultAsync(x=>x.EmailAddress == email.ToUpper());
            return findUser;
        }
        public async Task<ResetPassword> GetUserCodeCompared(string email)
        {
            var findUser = await _context.users.FirstOrDefaultAsync(x=>x.EmailAddress == email.ToUpper());
            if(findUser == null)
                return null;
            var UserCode = (from r in _context.resetPasswords
                            join u in _context.users on r.UserId equals u.Id
                            where r.UserId == findUser.Id
                            select r).FirstOrDefault();
            return UserCode;
        }

        public async Task<User> GetUserById(int Id)
        {
            var user = await _context.users.FindAsync(Id);
            return user;
        }

        public async Task<User> InsertUser(RegisterDTO dto)
        {
            var user = new User
            {
                EmailAddress = dto.EmailAddress.ToUpper(),
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                RoleId = 2,//Id = 2(User)
                DepartmentId = dto.DepartmentId
            };
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<string> GetUserByEmailAndCode(RandomNumberDTO dto)
        {
            var UserEmail = (from r in _context.resetPasswords
                             join u in _context.users on r.UserId equals u.Id
                             where u.EmailAddress.ToLower() == dto.Email.ToLower() && r.RandomNumber == dto.RandomNumber
                             select new { u.EmailAddress, r.RandomNumber }).FirstOrDefault();
            if(UserEmail == null)
                return null;
            return UserEmail.ToString();
        }

        public async Task<User> ResetPassword(NewPasswordDTO dto)
        {
            var currentUser = await _context.users.FirstOrDefaultAsync(x => x.EmailAddress == dto.Email);
            if (currentUser == null)
                return null;
            currentUser.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            await _context.SaveChangesAsync();
            return currentUser;
        }

        public async Task<string> JSONToken(User user)
        {
            var userExists = await _context.users.FirstOrDefaultAsync(x => x.Id == user.Id);
            var userDepartment = await _context.departments.FirstOrDefaultAsync(x => x.Id == user.DepartmentId);
            //var userRoles = userDepartment.Id;
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.EmailAddress),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.UserData, user.DepartmentId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            authClaims.Add(new Claim(ClaimTypes.Role, userExists.RoleId.ToString()));
            var userIdentity = new ClaimsIdentity(authClaims, ClaimTypes.Name);
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidateAudience"],
                expires: DateTime.Now.AddHours(8),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256));
            var Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;
        }
    }
}   
