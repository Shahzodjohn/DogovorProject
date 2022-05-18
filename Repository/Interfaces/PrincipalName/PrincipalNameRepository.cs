namespace Repository.PrincipalName
{
    public class PrincipalNameRepository : IPrincipalNameRepository
    {
        private readonly AppDbContext _context;

        public PrincipalNameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response> DeletePrincipalName(int Id)
        {
            try
            {
                var principalNames = await _context.principalNames.FindAsync(Id);
                if (principalNames == null)
                    return new Response { Status = "400", Message = "Id does not exist!" };
                _context.principalNames.Remove(principalNames);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Successfully removed!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't removed", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<Entity.Entities.PrincipalName> GetPrincipalNameById(int id)
        {
            return await _context.principalNames.FindAsync(id);
        }

        public async Task<Response> InsertPrincipalName(PrincipalNameDTO dto)
        {
            try
            {
                var principal = new Entity.Entities.PrincipalName
                {
                    PrincipalFullName = dto.PrincipalFullName
                };
                await _context.principalNames.AddAsync(principal);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Entity is inserted! Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't inserted", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<List<Entity.Entities.PrincipalName>> PrincipalNameList()
        {
            return await _context.principalNames.ToListAsync();
        }

        public async Task<Response> PrincipalNameUpdate(Entity.Entities.PrincipalName PrincipalName)
        {
            var findPosition = await _context.principalNames.FindAsync(PrincipalName.Id);
            try
            {
                if (findPosition == null)
                    return new Response { Status = "400", Message = "Principal Name Found!" };
                findPosition.PrincipalFullName = PrincipalName.PrincipalFullName;
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while updating PrincipalNameUpdate", Message = ex.InnerException.ToString() };
            }
        }
    }
}
