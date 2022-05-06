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
        public Task<string> InsertIntoDocument(DocumentDTO dto);
        public Task<string> InsertIntoPrincopalInfo(PrincipalInfoDTO dto);
        public Task<string> InsertReceiversInfoId(ReceiversInfoDTO dto);
        public Task<string> InsertIntoPurposeId(PurposeDTO dto);
        public Task<string> InsertIntoValidatonDatas(ValidationDataDTO dto);
        public Task<string> OrderInfo(int orderId,string Path);
    }
}
