using AutoMarket.BusinessLogic.Interfaces;
using AutoMarket.Common.ViewModels.Car;
using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Enum;
using AutoMarket.Domain.Response;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.BusinessLogic.Implementations
{
    public class CarService : ICarService
    {
        private readonly IBaseRepository<Car> _baseRepository;

        public CarService(IBaseRepository<Car> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IBaseResponse<Car>> Create(CarViewModel carViewModel)
        {
            try
            {
                var car = new Car()
                {
                    Mark = carViewModel.Mark,
                    Model = carViewModel.Model,
                    Description = carViewModel.Description,
                    DateCreate = DateTime.Now,
                    Price = carViewModel.Price,
                    Speed = carViewModel.Speed,
                    TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)

                };

                await _baseRepository.Create(car);

                return new BaseResponse<Car>()
                {
                    StatusCode = StatusCode.Ok,
                    Data = car
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }           
        }

        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var car = await _baseRepository.GetAll().FirstOrDefaultAsync(x=> x.Id == id);
                if (car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.CarNotFound;
                    baseResponse.Data = false;
                    return new BaseResponse<bool>()
                    {
                        Description = "Car not found",
                        StatusCode = Domain.Enum.StatusCode.CarNotFound,
                        Data = false
                    };
                }

                await _baseRepository.Delete(car);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Delete] : {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Edit(int id, CarViewModel carViewModel)
        {
            try
            {
                var car = await _baseRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<Car>()
                    {
                        StatusCode = StatusCode.CarNotFound,
                        Description = "Car not found"
                    };
                }

                car.Mark = carViewModel.Mark;
                car.Model = carViewModel.Model;
                car.Speed = carViewModel.Speed;
                car.Price = carViewModel.Price;
                car.DateCreate = carViewModel.DateCreate;
                car.Description = carViewModel.Description;


                await _baseRepository.Update(car);
                return new BaseResponse<Car>()
                {
                    Data = car,
                    StatusCode = StatusCode.Ok
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode =  StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _baseRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car != null)
                {
                    baseResponse.Data = car;
                    baseResponse.StatusCode = StatusCode.Ok;
                    return baseResponse;
                }

                baseResponse.Description = "Car not found";
                baseResponse.StatusCode = StatusCode.CarNotFound;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Car>> GetCars()
        {
            try
            {
                var cars =  _baseRepository.GetAll().ToList();
                if (!cars.Any())
                {
                    return new BaseResponse<List<Car>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.Ok,
                    };
                }
                
                return new BaseResponse<List<Car>>()
                {
                    Data = cars,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
