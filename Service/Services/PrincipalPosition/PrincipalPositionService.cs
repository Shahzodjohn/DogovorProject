namespace Service.PrincipalPosition
{
    public class PrincipalPositionService : IPrincipalPositionService
    {
        private readonly IPrincipalPositionRepository _principal;

        public PrincipalPositionService(IPrincipalPositionRepository principal)
        {
            _principal = principal;
        }
        Response response = new Response();
        public async Task<string> DeletePrincipalPosition(int Id)
        {
            var message = await _principal.DeletePrincipalPosition(Id);
            if (message == null)
                return response.ToLog("400", "Error! Entity was not deleted!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<Entity.Entities.PrincipalPosition> GetPrincipalPositionById(int id)
        {
            var message = await _principal.GetPrincipalPositionById(id);
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> InsertPrincipalPosition(PrincipalPositionDTO dto)
        {
            var city = await _principal.InsertPrincipalPosition(dto);
            if (city == null)
                response.ToLog("400", "Error! Entity was not added!");
            if (city.Status == 200.ToString())
                return city.Status + ", " + city.Message;
            else
                return response.ToLog(city.Status, city.Message);
        }

        public async Task<List<Entity.Entities.PrincipalPosition>> PrincipalPositionList()
        {
            var message = await _principal.PrincipalPositionList();
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> PrincipalPositionUpdate(Entity.Entities.PrincipalPosition principalPosition)
        {
            var message = await _principal.PrincipalPositionUpdate(principalPosition);
            if (message == null)
                response.ToLog("400", "Error! Entity was not updated!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }
    }
}
