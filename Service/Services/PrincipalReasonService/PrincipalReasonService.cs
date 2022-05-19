namespace Service.PrincipalReasonService
{
    public class PrincipalReasonService : IPrincipalReasonService
    {
        private readonly IPrincipalReasonRepository _principal;

        public PrincipalReasonService(IPrincipalReasonRepository principal)
        {
            _principal = principal;
        }
        Response response = new Response();
        public async Task<PrincipalReason> GetPrincipalReasonById(int id)
        {
            var message = await _principal.GetPrincipalReasonById(id);
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> InsertPrincipalReason(PrincipalReasonDTO dto)
        {
            var city = await _principal.InsertPrincipalReason(dto);
            if (city == null)
                response.ToLog("400", "Error! Entity was not added!");
            if (city.Status == 200.ToString())
                return city.Status + ", " + city.Message;
            else
                return response.ToLog(city.Status, city.Message);
        }

        public async Task<string> PrincipalReasonDelete(int Id)
        {
            var message = await _principal.DeletePrincipalReason(Id);
            if (message == null)
                return response.ToLog("400", "Error! Entity was not Deleted!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<List<PrincipalReason>> PrincipalReasonList()
        {
            var message = await _principal.PrincipalReasonList();
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> PrincipalReasonUpdate(PrincipalReason principalReason)
        {
            var message = await _principal.PrincipalReasonUpdate(principalReason);
            if (message == null)
                response.ToLog("400", "Error! Entity was not updated!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }
    }
}
