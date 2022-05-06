using Entity.DataTransfer_s;
using Entity.ResponseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PrincipalPosition
{
    public interface IPrincipalPositionService
    {
        public Task<string> InsertPrincipalPosition(PrincipalPositionDTO dto);
        public Task<List<Entity.Entities.PrincipalPosition>> PrincipalPositionList();
        public Task<string> PrincipalPositionUpdate(Entity.Entities.PrincipalPosition principalPosition);
        public Task<string> DeletePrincipalPosition(int Id);
        public Task<Entity.Entities.PrincipalPosition> GetPrincipalPositionById(int id);
    }
}
