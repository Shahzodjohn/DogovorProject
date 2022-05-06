using Entity.DataTransfer_s.City;
using Entity.Entities;
using Entity.ResponseMessage;

namespace Repository.CityRepository
{
    public interface ICityRepository
    {
        public Task<Response> InsertCity(CityDTO dto);
        public Task<List<City>> CityList();
        public Task<Response> CityUpdate(City city);
        public Task<Response> DeleteCity(int Id);
        public Task<City> GetCityById(int id);
    }
}
