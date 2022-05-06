using Entity.DataTransfer_s;
using Entity.ResponseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PrincipalName
{
    public interface IPrincipalNameRepository
    {
        public Task<Response> InsertPrincipalName(PrincipalNameDTO dto);
        public Task<List<Entity.Entities.PrincipalName>> PrincipalNameList();
        public Task<Response> PrincipalNameUpdate(Entity.Entities.PrincipalName PrincipalName);
        public Task<Response> DeletePrincipalName(int Id);
        public Task<Entity.Entities.PrincipalName> GetPrincipalNameById(int id);
    }
}
