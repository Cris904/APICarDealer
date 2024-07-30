using CarDealershipAPI.Data;
using CarDealershipAPI.Models;
using CarDealershipAPI.Repositories.Interfaces;

namespace CarDealershipAPI.Repositories.Implementations
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarDealershipContext context) : base(context) { }
    }
}
