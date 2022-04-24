using Entity.DataTransfer_s.FormApplication;
using Entity.ResponseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IFormRepository
    {
        public Task<Response> InsertIntoDocument(DocumentDTO dto);
        public Task<Response> InsertIntoPrincipalInfo(PrincipalInfoDTO dto);
        public Task<Response> InsertIntoPurposeId(PurposeDTO dto);
        public Task<Response> InsertIntoValidatonDatas(ValidationDataDTO dto);
        public Task<Response> InsertReceiversInfoId(ReceiversInfoDTO dto);
    }
}
