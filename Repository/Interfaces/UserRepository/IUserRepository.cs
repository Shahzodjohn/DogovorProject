using Entity;
using Entity.DataTransfer_s;
using Entity.DataTransfer_s.Authorization;
using Entity.Entities;
using Entity.ResponseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> InsertUser(RegisterDTO dto);
        public Task<User> GetUserbyEmail(string email);
        public Task<string> JSONToken(User user);
        public Task<User> GetUserById(int Id);
        public Task<ResetPassword> GetUserCodeCompared(string email);
        public string GetUserByEmailAndCode(RandomNumberDTO dto);
        public Task<User> ResetPassword(NewPasswordDTO dto);
    }
}
