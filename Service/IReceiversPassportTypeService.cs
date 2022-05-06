using Entity.DataTransfer_s;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IReceiversPassportTypeService
    {
        public Task<string> InsertReceiversPassportType(ReceiversPassportTypeDTO dto);
        public Task<List<ReceiversPassportType>> ReceiversPassportTypeList();
        public Task<string> ReceiversPassportTypeUpdate(ReceiversPassportType principalName);
        public Task<string> DeleteReceiversPassportType(int Id);
        public Task<ReceiversPassportType> GetReceiversPassportTypeById(int id);
    }   
}
