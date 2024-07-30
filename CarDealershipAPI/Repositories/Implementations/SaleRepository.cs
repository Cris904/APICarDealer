using CarDealershipAPI.Data;
using CarDealershipAPI.Models;
using CarDealershipAPI.Repositories.Interfaces;

namespace CarDealershipAPI.Repositories.Implementations
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(CarDealershipContext context) : base(context) { }
    }
}
