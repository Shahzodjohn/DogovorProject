using ConnectionProvider;
using Entity.DataTransfer_s;
using Entity.Entities;
using Entity.ResponseMessage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ReceiversPassportTypeRepository
{
    public class ReceiversPassportTypeRepository : IReceiversPassportTypeRepository
    {
        private readonly AppDbContext _context;

        public ReceiversPassportTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response> DeleteReceiversPassportType(int Id)
        {
            try
            {
                var receiversPassportTypes = await _context.receiversPassportTypes.FindAsync(Id);
                if (receiversPassportTypes == null)
                    return new Response { Status = "400", Message = "Id does not exist!" };
                _context.receiversPassportTypes.Remove(receiversPassportTypes);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Successfully removed!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't removed", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<ReceiversPassportType> GetReceiversPassportTypeById(int id)
        {
            return await _context.receiversPassportTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Response> InsertReceiversPassportType(ReceiversPassportTypeDTO dto)
        {
            try
            {
                var ReceiversPassportType = new ReceiversPassportType
                {
                     Type = dto.Type
                };
                await _context.receiversPassportTypes.AddAsync(ReceiversPassportType);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Entity is inserted! Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't inserted", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<List<ReceiversPassportType>> ReceiversPassportTypeList()
        {
            return await _context.receiversPassportTypes.ToListAsync();
        }

        public async Task<Response> ReceiversPassportTypeUpdate(ReceiversPassportType receiversPassportType)
        {
            var findReceiversPassportType = await _context.receiversPassportTypes.FindAsync(receiversPassportType.Id);
            try
            {
                if (findReceiversPassportType == null)
                    return new Response { Status = "400", Message = "Principal Place Not Found!" };
                findReceiversPassportType.Type = receiversPassportType.Type;
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while updating Principal Place", Message = ex.InnerException.ToString() };
            }
        }
    }
}
