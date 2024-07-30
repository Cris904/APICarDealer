using CarDealershipAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipAPI.Services.Interfaces
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAllSales();
        Task<Sale> GetSaleById(int id);
        Task AddSale(Sale sale);
        Task UpdateSale(Sale sale);
        Task DeleteSale(int id);
        Task<string> GenerateSaleReport(); // Cambiar el tipo de retorno a string
    }
}
