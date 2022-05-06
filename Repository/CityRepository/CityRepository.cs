using ConnectionProvider;
using Entity.DataTransfer_s.City;
using Entity.Entities;
using Entity.ResponseMessage;
using Microsoft.EntityFrameworkCore;

namespace Repository.CityRepository
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response> InsertCity(CityDTO dto)
        {
            try
            {
                var city = new City { CityName = dto.CityName };
                await _context.cities.AddAsync(city);
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "City is successfully inserted" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || City is not inserted!", Message = ex.InnerException.ToString() };
            }
        }
        public async Task<List<City>> CityList()
        {
            return await _context.cities.ToListAsync();
        }
        public async Task<City> GetCityById(int id)
        {
           var find = await _context.cities.FindAsync(id);
            if (find == null) return null;
            return find;
        }
        public async Task<Response> CityUpdate(City city)
        {
            var findCity = await _context.cities.FindAsync(city.Id);
            try
            {
                if (findCity == null)
                    return new Response { Status = "400", Message = "City Not Found!" };
                findCity.CityName = city.CityName;
                await _context.SaveChangesAsync();
                return new Response { Status = "200", Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while updating CityUpdate", Message = ex.InnerException.ToString() };
            }
        }
        public async Task<Response> DeleteCity(int Id)
        {
            var findCity = await _context.cities.FindAsync(Id);
            try
            {
                if (findCity == null)
                    return new Response { Status = "400", Message = "City not found!" };
                _context.cities.Remove(findCity);
                await _context.SaveChangesAsync(); 
                return new Response { Status = "200", Message = "Success!" };
            }
            catch (Exception ex)
            {
                return new Response { Status = "400 || Error while deleting city", Message = ex.InnerException.ToString() };
            }
        }
    }
}
