
using AutoMarket.BusinessLogic.Interfaces;
using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Response;

namespace AutoMarket.BusinessLogic.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<BaseResponse<IEnumerable<Car>>> GetCars()
        {
           var baseResponse = new BaseResponse<IEnumerable<Car>>();

            try
            {
                var cars = await _carRepository.Select();
                if (cars.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.Ok;
                    return baseResponse;
                }
                baseResponse.Data = cars;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}"
                };
            }   
        }
    }
}
