using AutoMarket.Common.ViewModels.Car;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Response;

namespace AutoMarket.BusinessLogic.Interfaces
{
    public interface ICarService
    {
        Task<IBaseResponse<IEnumerable<Car>>> GetCars();
        Task<IBaseResponse<Car>> GetCar(int id);
        Task<IBaseResponse<Car>> GetCarByName(string name);

        Task<IBaseResponse<bool>> Delete(int id);

        Task<IBaseResponse<Car>> Edit(int id, CarViewModel carViewModel);
        Task<IBaseResponse<CarViewModel>> Create(CarViewModel carViewModel);
    }
}
