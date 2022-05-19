namespace Service.PrincipalName
{
    public class PrincipalNameService : IPrincipalNameService
    {
        private readonly IPrincipalNameRepository _repository;

        public PrincipalNameService(IPrincipalNameRepository repository)
        {
            _repository = repository;
        }
        Response response = new Response();
        public async Task<string> DeletePrincipalName(int Id)
        {
            var message = await _repository.DeletePrincipalName(Id);
            if (message == null)
                return response.ToLog("400", "Error! Entity was not added!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<Entity.Entities.PrincipalName> GetPrincipalNameById(int id)
        {
            var message = await _repository.GetPrincipalNameById(id);
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> InsertPrincipalName(PrincipalNameDTO dto)
        {
            var city = await _repository.InsertPrincipalName(dto);
            if (city == null)
                response.ToLog("400", "Error! Entity was not added!");
            if (city.Status == 200.ToString())
                return city.Status + ", " + city.Message;
            else
                return response.ToLog(city.Status, city.Message);
        }

        public async Task<List<Entity.Entities.PrincipalName>> PrincipalNameList()
        {
            var message = await _repository.PrincipalNameList();
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> PrincipalNameUpdate(Entity.Entities.PrincipalName principalName)
        {
            var message = await _repository.PrincipalNameUpdate(principalName);
            if (message == null)
                response.ToLog("400", "Error! Entity was not updated!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }
    }
}
