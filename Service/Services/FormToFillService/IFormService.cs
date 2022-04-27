using Entity.DataTransfer_s.FormApplication;
using Entity.Entities;
using Entity.ResponseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.FormToFillService
{
    public interface IFormService
    {
        public Task<Response> InsertIntoDocument(DocumentDTO dto);
        public Task<Response> InsertIntoPrincopalInfo(PrincipalInfoDTO dto);
        public Task<Response> InsertReceiversInfoId(ReceiversInfoDTO dto);
        public Task<Response> InsertIntoPurposeId(PurposeDTO dto);
        public Task<Response> InsertIntoValidatonDatas(ValidationDataDTO dto);
        public Task<Response> OrderInfo(int orderId,string Path);
    }
}
