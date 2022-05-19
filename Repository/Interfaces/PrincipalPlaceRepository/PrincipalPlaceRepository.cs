namespace Repository.PrincipalPlaceRepository
{
    public class PrincipalPlaceRepository : IPrincipalPlaceRepository
    {
        private readonly AppDbContext _context;

        public PrincipalPlaceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response> DeletePrincipalPlace(int Id)
        {
            try
            {
                var principalPlaces = await _context.principalPlaces.FindAsync(Id);
                if (principalPlaces == null)
                    return new Response { Status = "400", Message = "Id does not exist!" };
                _context.principalPlaces.Remove(principalPlaces);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Successfully removed!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't removed", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<PrincipalPlace> GetPrincipalPlaceById(int id)
        {
            return await _context.principalPlaces.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Response> InsertPrincipalPlace(PrincipalPlaceDTO dto)
        {
            try
            {
                var principal = new PrincipalPlace
                {
                    PrincipalPlaceName = dto.PrincipalPlaceName
                };
                await _context.principalPlaces.AddAsync(principal);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Entity is inserted! Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Entity wasn't inserted", Message = ex.InnerException.ToString() };
            }
        }

        public async Task<List<PrincipalPlace>> PrincipalPlaceList()
        {
            return await _context.principalPlaces.ToListAsync();
        }

        public async Task<Response> PrincipalPlaceUpdate(PrincipalPlace principalPlace)
        {
            var findPosition = await _context.principalPlaces.FindAsync(principalPlace.Id);
            try
            {
                if (findPosition == null)
                    return new Response { Status = "400", Message = "Principal Place Not Found!" };
                findPosition.PrincipalPlaceName = principalPlace.PrincipalPlaceName;
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
