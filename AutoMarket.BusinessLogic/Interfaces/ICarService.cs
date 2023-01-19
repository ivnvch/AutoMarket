using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Response;

namespace AutoMarket.BusinessLogic.Interfaces
{
    public interface ICarService
    {
        Task<BaseResponse<IEnumerable<Car>>> GetCars();
    }
}
