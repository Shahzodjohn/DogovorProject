namespace Repository.PrincipalPosition
{
    public class PrincipalPositionRepository : IPrincipalPositionRepository
    {
        private readonly AppDbContext _context;

        public PrincipalPositionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Entity.Entities.PrincipalPosition> GetPrincipalPositionById(int id)
        {
            return await _context.principalPositions.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Response> InsertPrincipalPosition(PrincipalPositionDTO dto)
        {
            try
            {
                var principal = new Entity.Entities.PrincipalPosition
                {
                    PositionName = dto.PositionName
                };
                await _context.principalPositions.AddAsync(principal);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Entity is inserted! Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't inserted", Message = ex.InnerException.ToString()};
            }
        }

        public async Task<Response> DeletePrincipalPosition(int Id)
        {
            try
            {
                var princPosition = await _context.principalPositions.FindAsync(Id);
                if(princPosition == null)
                    return new Response { Status = "400", Message = "Id does not exist!" };
                _context.principalPositions.Remove(princPosition);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Successfully removed!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't removed", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<List<Entity.Entities.PrincipalPosition>> PrincipalPositionList()
        {
            return await _context.principalPositions.ToListAsync();
        }

        public async Task<Response> PrincipalPositionUpdate(Entity.Entities.PrincipalPosition principalPosition)
        {
            var findPosition = await _context.principalPositions.FindAsync(principalPosition.Id);
            try
            {
                if (findPosition == null)
                    return new Response { Status = "400", Message = "City Not Found!" };
                findPosition.PositionName = principalPosition.PositionName;
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while updating CityUpdate", Message = ex.InnerException.ToString() };
            }
        }
    }
}
