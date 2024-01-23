using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            var cars = _carService.GetAll();
            return Ok(cars);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<Car> Add(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedCar = _carService.Add(car);
            return Ok(addedCar);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            var car = _carService.GetById(id);
            if(car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var res = _carService.Delete(id);
            if (res == "Failed")
            {
                return BadRequest("Car not found");
            }
            return Ok(new { message = "deleted" });
        }

        [Authorize (Roles ="Admin")]
        [HttpPut]
        public ActionResult<Car> Update(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedCar = _carService.Update(car);
            return Ok(updatedCar);
        }
    }
}
