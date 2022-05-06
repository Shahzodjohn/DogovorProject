using Entity.DataTransfer_s.City;
using Entity.ResponseMessage;
using Repository.CityRepository;
using Entity.Entities;

namespace Service.Services.City
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        Response response = new Response();
        public async Task<string> InsertCity(CityDTO dto)
        {
            var city = await _cityRepository.InsertCity(dto);
            if (city == null)
                response.ToLog("400", "Error! Entity was not added!");
            if(city.Status == 200.ToString())
                return city.Status + ", " + city.Message;
            else
                return response.ToLog(city.Status, city.Message);
        }
        public async Task<string> UpdateCity(Entity.Entities.City city)
        {
            var message = await _cityRepository.CityUpdate(city);
            if (message == null)
                response.ToLog("400", "Error! Entity was not updated!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }
        public async Task<List<Entity.Entities.City>> GetCities()
        {
            var message = await _cityRepository.CityList();
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }
        public async Task<Entity.Entities.City> GetCitybyId(int Id)
        {
            var message = await _cityRepository.GetCityById(Id);
            if (message == null)
                response.ToLog("400", "Error! Entities are null!");
            return message;
        }
        public async Task<string> DeleteCity(int Id)
        {
            var message = await _cityRepository.DeleteCity(Id);
            if (message == null)
                return response.ToLog("400", "Error! Entity was not added!");
            if (message.Status == 200.ToString())
                return message.Status + ", " + message.Message;
            else
                return response.ToLog(message.Status, message.Message);
        }
    }
}
