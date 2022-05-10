using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICodeResetRepository
    {
        public Task<ResetPassword> GetUserCodebyId(int id);
        public Task<ResetPassword> Insert(string randomNumber, int UserId, DateTime date);
    }
}
