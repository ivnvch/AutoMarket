using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Controllers
{
    //[ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Select()
        {
            var response = await _carRepository.Select();

            //Car car = new Car()
            //{
            //    Mark = "BMW",
            //    Model = "M5", 
            //    DateCreate = DateTime.Now,
            //    Price = 250000,
            //    Description = "Пафосная тачка",
            //    Speed = 300,
            //    TypeCar = Domain.Enum.TypeCar.Sedan
            //};
            //await _carRepository.Create(car);
            //await _carRepository.Delete(car);
            return View(response);
        }
    }
}
