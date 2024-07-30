using CarDealershipAPI.Models;
using CarDealershipAPI.Repositories.Interfaces;
using CarDealershipAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipAPI.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _carRepository.GetAll();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _carRepository.GetById(id);
        }

        public async Task AddCar(Car car)
        {
            await _carRepository.Add(car);
        }

        public async Task UpdateCar(Car car)
        {
            await _carRepository.Update(car);
        }

        public async Task DeleteCar(int id)
        {
            await _carRepository.Delete(id);
        }
    }
}
