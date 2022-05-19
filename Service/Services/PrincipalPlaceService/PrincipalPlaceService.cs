namespace Service.PrincipalPlaceService
{
    public class PrincipalPlaceService : IPrincipalPlaceService
    {
        private readonly IPrincipalPlaceRepository _repository;

        public PrincipalPlaceService(IPrincipalPlaceRepository repository)
        {
            _repository = repository;
        }
        Response response = new Response(); 
        public async Task<string> DeletePrincipalPlace(int Id)
        {
            var message = await _repository.DeletePrincipalPlace(Id);
            if (message == null)
                return response.ToLog("400", "Error! Entity was not added!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<PrincipalPlace> GetPrincipalPlaceById(int id)
        {
            var message = await _repository.GetPrincipalPlaceById(id);
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> InsertPrincipalPlace(PrincipalPlaceDTO dto)
        {
            var message = await _repository.InsertPrincipalPlace(dto);
            if (message == null)
                response.ToLog("400", "Error! Entity was not added!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<List<PrincipalPlace>> PrincipalPlaceList()
        {
            var message = await _repository.PrincipalPlaceList();
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> PrincipalPlaceUpdate(PrincipalPlace principalPlace)
        {
            var message = await _repository.PrincipalPlaceUpdate(principalPlace);
            if (message == null)
                response.ToLog("400", "Error! Entity was not updated!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }
    }
}
