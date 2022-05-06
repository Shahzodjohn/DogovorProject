using Entity.DataTransfer_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Purpose
{
    public interface IPurposeService
    {
        public Task<string> InsertPurpose(PurposeModelDTO dto);
        public Task<List<Entity.Entities.Purpose>> PurposeList();
        public Task<string> PurposeUpdate(Entity.Entities.Purpose principalReason);
        public Task<string> PurposeDelete(int Id);
        public Task<Entity.Entities.Purpose> GetPurposeById(int id);
    }
}
