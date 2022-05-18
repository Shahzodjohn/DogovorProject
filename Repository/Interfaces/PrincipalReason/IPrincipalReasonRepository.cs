using Entity.DataTransfer_s;
using Entity.ResponseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PrincipalReason
{
    public interface IPrincipalReasonRepository
    {
        public Task<Response> InsertPrincipalReason(PrincipalReasonDTO dto);
        public Task<List<Entity.Entities.PrincipalReason>> PrincipalReasonList();
        public Task<Response> PrincipalReasonUpdate(Entity.Entities.PrincipalReason principalReason);
        public Task<Response> DeletePrincipalReason(int Id);
        public Task<Entity.Entities.PrincipalReason> GetPrincipalReasonById(int id);
    }
}
