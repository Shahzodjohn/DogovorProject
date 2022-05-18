using Entity.DataTransfer_s;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PrincipalPlaceService
{
    public interface IPrincipalPlaceService
    {
        public Task<string> InsertPrincipalPlace(PrincipalPlaceDTO dto);
        public Task<List<PrincipalPlace>> PrincipalPlaceList();
        public Task<string> PrincipalPlaceUpdate(PrincipalPlace principalPlace);
        public Task<string> DeletePrincipalPlace(int Id);
        public Task<PrincipalPlace> GetPrincipalPlaceById(int id);
    }
}
