using Entity.DataTransfer_s;
using Entity.ResponseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PrincipalPlaceRepository
{
    public interface IPrincipalPlaceRepository
    {
        public Task<Response> InsertPrincipalPlace(PrincipalPlaceDTO dto);
        public Task<List<Entity.Entities.PrincipalPlace>> PrincipalPlaceList();
        public Task<Response> PrincipalPlaceUpdate(Entity.Entities.PrincipalPlace principalPlace);
        public Task<Response> DeletePrincipalPlace(int Id);
        public Task<Entity.Entities.PrincipalPlace> GetPrincipalPlaceById(int id);
    }
}
