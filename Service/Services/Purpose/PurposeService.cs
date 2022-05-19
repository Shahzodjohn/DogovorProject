namespace Service.Purpose
{
    public class PurposeService : IPurposeService
    {
        private readonly IPurposeRepository _purposeRepository;

        public PurposeService(IPurposeRepository purposeRepository)
        {
            _purposeRepository = purposeRepository;
        }
        Response response = new Response();
        public async Task<Entity.Entities.Purpose> GetPurposeById(int id)
        {
            var message = await _purposeRepository.GetPurposeById(id);
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> InsertPurpose(PurposeModelDTO dto)
        {
            var message = await _purposeRepository.InsertPurpose(dto);
            if (message == null)
                response.ToLog("400", "Error! Entity was not added!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<string> PurposeDelete(int Id)
        {
            var message = await _purposeRepository.DeletePurpose(Id);
            if (message == null)
                return response.ToLog("400", "Error! Entity was not Deleted!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<List<Entity.Entities.Purpose>> PurposeList()
        {
            var message = await _purposeRepository.PurposeList();
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> PurposeUpdate(Entity.Entities.Purpose principalReason)
        {
            var message = await _purposeRepository.PurposeUpdate(principalReason);
            if (message == null)
                response.ToLog("400", "Error! Entity was not updated!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }
    }
}
