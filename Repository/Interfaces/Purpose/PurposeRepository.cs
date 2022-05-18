using ConnectionProvider;
using Entity.DataTransfer_s;
using Entity.ResponseMessage;
using Microsoft.EntityFrameworkCore;

namespace Repository.Purpose
{
    public class PurposeRepository : IPurposeRepository
    {
        private readonly AppDbContext _context;

        public PurposeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response> DeletePurpose(int Id)
        {
            try
            {
                var purpose = await _context.purposes.FindAsync(Id);
                if (purpose == null)
                    return new Response { Status = "400", Message = "Id does not exist!" };
                _context.purposes.Remove(purpose);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Successfully removed!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't removed!", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<Entity.Entities.Purpose> GetPurposeById(int id)
        {
            return await _context.purposes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Response> InsertPurpose(PurposeModelDTO dto)
        {
            try
            {
                var PurposeText = new Entity.Entities.Purpose
                {
                     PurposeText = dto.PurposeText
                };
                await _context.purposes.AddAsync(PurposeText);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Entity is inserted! Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't inserted!", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<List<Entity.Entities.Purpose>> PurposeList()
        {
            return await _context.purposes.ToListAsync();
        }

        public async Task<Response> PurposeUpdate(Entity.Entities.Purpose purpose)
        {
            var principalReasons = await _context.purposes.FindAsync(purpose.Id);
            try
            {
                if (principalReasons == null)
                    return new Response { Status = "400", Message = "Principal Place Not Found!" };
                principalReasons.PurposeText = purpose.PurposeText;
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
