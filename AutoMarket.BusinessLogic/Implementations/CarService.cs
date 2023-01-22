
using AutoMarket.BusinessLogic.Interfaces;
using AutoMarket.Common.ViewModels.Car;
using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using AutoMarket.Domain.Enum;
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

        public async Task<IBaseResponse<CarViewModel>> Create(CarViewModel carViewModel)
        {
            var baseResponse = new BaseResponse<CarViewModel>();
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

                await _carRepository.Create(car);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
            return baseResponse;
           
        }

        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseResponse.Description = "Car not found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.CarNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }

                await _carRepository.Delete(car);

                return baseResponse;
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
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.Get(id);
                if (car == null)
                {
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    baseResponse.Description = "Car not found";
                    return baseResponse;
                }

                car.Mark = carViewModel.Mark;
                car.Model = carViewModel.Model;
                car.Speed = carViewModel.Speed;
                car.Price = carViewModel.Price;
                car.DateCreate = carViewModel.DateCreate;
                car.Description = carViewModel.Description;


                await _carRepository.Update(car);
                return baseResponse;
                //TypeCar
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<Car>();

            try
            {
                var car = await _carRepository.Get(id);
                if (car != null)
                {
                    baseResponse.Data = car;
                    baseResponse.StatusCode = Domain.Enum.StatusCode.Ok;
                    return baseResponse;
                }

                baseResponse.Description = "Car not found";
                baseResponse.StatusCode = Domain.Enum.StatusCode.CarNotFound;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCar] : {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
           var baseResponse = new BaseResponse<Car>();
            try
            {
                var carByName = await _carRepository.GetByName(name);
                if (carByName == null)
                {
                    baseResponse.Description = "Car not Found";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.CarNotFound;
                    return baseResponse;
                }

                baseResponse.Data = carByName;
                baseResponse.StatusCode = Domain.Enum.StatusCode.Ok;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Description = $"[GetCarByName] : {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
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
                baseResponse.StatusCode = StatusCode.Ok;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Car>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }   
        }
    }
}
