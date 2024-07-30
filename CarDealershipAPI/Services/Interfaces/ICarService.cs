using CarDealershipAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipAPI.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarById(int id);
        Task AddCar(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(int id);
    }
}
