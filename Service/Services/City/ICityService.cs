
using Entity.DataTransfer_s.City;
using Entity.Entities;
using Entity.ResponseMessage;

namespace Service
{
    public interface ICityService
    {
        public Task<string> InsertCity(CityDTO dto);
        public Task<string> UpdateCity(City city);
        public Task<List<Entity.Entities.City>> GetCities();
        public Task<Entity.Entities.City> GetCitybyId(int Id);
        public Task<string> DeleteCity(int Id);
    }
}
