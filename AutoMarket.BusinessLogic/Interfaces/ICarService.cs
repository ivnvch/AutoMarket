using AutoMarket.Common.ViewModels.Car;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Response;

namespace AutoMarket.BusinessLogic.Interfaces
{
    public interface ICarService
    {
        IBaseResponse<List<Car>> GetCars();
        Task<IBaseResponse<Car>> GetCar(int id);
       

        Task<IBaseResponse<bool>> Delete(int id);

        Task<IBaseResponse<Car>> Edit(int id, CarViewModel carViewModel);
        Task<IBaseResponse<Car>> Create(CarViewModel carViewModel);
    }
}
