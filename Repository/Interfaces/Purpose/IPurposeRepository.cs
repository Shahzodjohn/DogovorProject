using Entity.DataTransfer_s;
using Entity.ResponseMessage;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Purpose
{
    public interface IPurposeRepository
    {
        public Task<Response> InsertPurpose(PurposeModelDTO dto);
        public Task<List<Entity.Entities.Purpose>> PurposeList();
        public Task<Response> PurposeUpdate(Entity.Entities.Purpose purpose);
        public Task<Response> DeletePurpose(int Id);
        public Task<Entity.Entities.Purpose> GetPurposeById(int id);
    }
}
