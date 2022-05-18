using Entity.DataTransfer_s;
using Entity.Entities;
using Entity.ResponseMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ReceiversPassportTypeRepository
{
    public interface IReceiversPassportTypeRepository
    {
        public Task<Response> InsertReceiversPassportType(ReceiversPassportTypeDTO dto);
        public Task<List<ReceiversPassportType>> ReceiversPassportTypeList();
        public Task<Response> ReceiversPassportTypeUpdate(ReceiversPassportType receiversPassportType);
        public Task<Response> DeleteReceiversPassportType(int Id);
        public Task<ReceiversPassportType> GetReceiversPassportTypeById(int id);
    }
}
