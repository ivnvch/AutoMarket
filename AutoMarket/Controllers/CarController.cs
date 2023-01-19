using AutoMarket.BusinessLogic.Interfaces;
using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AutoMarket.Controllers
{
   // [ApiController]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Select()
        {
            var response = await _carService.GetCars();
            return View(response.Data);
        }
    }
}
