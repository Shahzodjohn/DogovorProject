using Entity.DataTransfer_s;
using Entity.Entities;
using Entity.ResponseMessage;
using Repository.ReceiversPassportTypeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReceiversPassportTypeService : IReceiversPassportTypeService
    {
        private readonly IReceiversPassportTypeRepository _repository;

        public ReceiversPassportTypeService(IReceiversPassportTypeRepository repository)
        {
            _repository = repository;
        }
        Response response = new Response();
        public async Task<string> DeleteReceiversPassportType(int Id)
        {
            var message = await _repository.DeleteReceiversPassportType(Id);
            if (message == null)
                return response.ToLog("400", "Error! Entity was not added!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<ReceiversPassportType> GetReceiversPassportTypeById(int id)
        {
            var message = await _repository.GetReceiversPassportTypeById(id);
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> InsertReceiversPassportType(ReceiversPassportTypeDTO dto)
        {
            var message = await _repository.InsertReceiversPassportType(dto);
            if (message == null)
                response.ToLog("400", "Error! Entity was not added!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }

        public async Task<List<ReceiversPassportType>> ReceiversPassportTypeList()
        {
            var message = await _repository.ReceiversPassportTypeList();
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }

        public async Task<string> ReceiversPassportTypeUpdate(ReceiversPassportType principalName)
        {
            var message = await _repository.ReceiversPassportTypeUpdate(principalName);
            if (message == null)
                response.ToLog("400", "Error! Entity was not updated!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }
    }
}
