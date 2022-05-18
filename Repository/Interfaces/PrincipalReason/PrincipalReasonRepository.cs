using ConnectionProvider;
using Entity.DataTransfer_s;
using Entity.ResponseMessage;
using Microsoft.EntityFrameworkCore;

namespace Repository.PrincipalReason
{
    public class PrincipalReasonRepository : IPrincipalReasonRepository
    {
        private readonly AppDbContext _context;

        public PrincipalReasonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response> DeletePrincipalReason(int Id)
        {
            try
            {
                var PrincipalReason = await _context.principalReasons.FindAsync(Id);
                if (PrincipalReason == null)
                    return new Response { Status = "400", Message = "Id does not exist!" };
                _context.principalReasons.Remove(PrincipalReason);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Successfully removed!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't removed", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<Entity.Entities.PrincipalReason> GetPrincipalReasonById(int id)
        {
            return await _context.principalReasons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Response> InsertPrincipalReason(PrincipalReasonDTO dto)
        {
            try
            {
                var principalReason = new Entity.Entities.PrincipalReason
                {
                    ReasonType = dto.ReasonType
                };
                await _context.principalReasons.AddAsync(principalReason);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Entity is inserted! Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't inserted", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<List<Entity.Entities.PrincipalReason>> PrincipalReasonList()
        {
            return await _context.principalReasons.ToListAsync();
        }

        public async Task<Response> PrincipalReasonUpdate(Entity.Entities.PrincipalReason principalReason)
        {
            var principalReasons = await _context.principalReasons.FindAsync(principalReason.Id);
            try
            {
                if (principalReasons == null)
                    return new Response { Status = "400", Message = "Principal Place Not Found!" };
                principalReasons.ReasonType = principalReason.ReasonType;
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
