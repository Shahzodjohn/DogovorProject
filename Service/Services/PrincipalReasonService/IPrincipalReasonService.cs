using Entity.DataTransfer_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PrincipalReasonService
{
    public interface IPrincipalReasonService
    {
        public Task<string> InsertPrincipalReason(PrincipalReasonDTO dto);
        public Task<List<Entity.Entities.PrincipalReason>> PrincipalReasonList();
        public Task<string> PrincipalReasonUpdate(Entity.Entities.PrincipalReason principalReason);
        public Task<string> PrincipalReasonDelete(int Id);
        public Task<Entity.Entities.PrincipalReason> GetPrincipalReasonById(int id);
    }
}
