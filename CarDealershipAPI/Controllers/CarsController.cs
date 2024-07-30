using CarDealershipAPI.Models;
using CarDealershipAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> Get()
        {
            return await _carService.GetAllCars();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return car;
        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post([FromBody] Car car)
        {
            await _carService.AddCar(car);
            return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            await _carService.UpdateCar(car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            await _carService.DeleteCar(id);
            return NoContent();
        }
    }
}
