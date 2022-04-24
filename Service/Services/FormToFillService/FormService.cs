using Entity.DataTransfer_s.FormApplication;
using Entity.ResponseMessage;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.FormToFillService
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _fRepository;

        public FormService(IFormRepository fRepository)
        {
            _fRepository = fRepository;
        }

        public async Task<Response> InsertIntoDocument(DocumentDTO dto)
        {
              var message =  await _fRepository.InsertIntoDocument(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message};
            else
                return new Response { Status = message.Status, Message = message.Message };

        }

        public async Task<Response> InsertIntoPrincopalInfo(PrincipalInfoDTO dto)
        {
            var message = await _fRepository.InsertIntoPrincipalInfo(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message };
            else
                return new Response { Status = message.Status, Message = message.Message };
        }
        public async Task<Response> InsertReceiversInfoId(ReceiversInfoDTO dto)
        {
            var message = await _fRepository.InsertReceiversInfoId(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message };
            else
                return new Response { Status = message.Status, Message = message.Message };
        }

        public async Task<Response> InsertIntoPurposeId(PurposeDTO dto)
        {
            var message = await _fRepository.InsertIntoPurposeId(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message };
            else
                return new Response { Status = message.Status, Message = message.Message };
        }

        public async Task<Response> InsertIntoValidatonDatas(ValidationDataDTO dto)
        {
            var message = await _fRepository.InsertIntoValidatonDatas(dto);
            if (message.Status == 200.ToString())
                return new Response { Status = message.Status, Message = message.Message };
            else
                return new Response { Status = message.Status, Message = message.Message };
        }

        
    }
}
