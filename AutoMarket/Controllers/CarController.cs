using AutoMarket.BusinessLogic.Interfaces;
using AutoMarket.Common.ViewModels.Car;
using AutoMarket.DAL.Interfaces;
using AutoMarket.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
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
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await _carService.GetCar(id);
            if (car.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(car.Data);
            }

            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
          var response = await _carService.Delete(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return RedirectToAction("Select");
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save (int id)
        {
            if (id == 0)
            {
                return View();
            }
            var response = await _carService.GetCar(id);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                if (carViewModel.Id == 0)
                {
                    await _carService.Create(carViewModel);
                }
                else
                {
                    await _carService.Edit(carViewModel.Id, carViewModel);
                }
            }
            return RedirectToAction("Select");
        }
    }
}
