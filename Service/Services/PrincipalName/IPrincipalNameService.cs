using Entity.DataTransfer_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PrincipalName
{
    public interface IPrincipalNameService
    {
        public Task<string> InsertPrincipalName(PrincipalNameDTO dto);
        public Task<List<Entity.Entities.PrincipalName>> PrincipalNameList();
        public Task<string> PrincipalNameUpdate(Entity.Entities.PrincipalName principalName);
        public Task<string> DeletePrincipalName(int Id);
        public Task<Entity.Entities.PrincipalName> GetPrincipalNameById(int id);
    }
}
