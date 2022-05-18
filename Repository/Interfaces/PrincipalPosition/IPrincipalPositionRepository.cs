using Entity.DataTransfer_s;
using Entity.ResponseMessage;


namespace Repository.PrincipalPosition
{
    public interface IPrincipalPositionRepository
    {
        public Task<Response> InsertPrincipalPosition(PrincipalPositionDTO dto);
        public Task<List<Entity.Entities.PrincipalPosition>> PrincipalPositionList();
        public Task<Response> PrincipalPositionUpdate(Entity.Entities.PrincipalPosition principalPosition);
        public Task<Response> DeletePrincipalPosition(int Id);
        public Task<Entity.Entities.PrincipalPosition> GetPrincipalPositionById(int id);
    }
}
