using CarDealershipAPI.Models;
using CarDealershipAPI.Repositories.Interfaces;
using CarDealershipAPI.Services.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace CarDealershipAPI.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly string _connectionString;

        public SaleService(ISaleRepository saleRepository, IConfiguration configuration)
        {
            _saleRepository = saleRepository;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            return await _saleRepository.GetAll();
        }

        public async Task<Sale> GetSaleById(int id)
        {
            return await _saleRepository.GetById(id);
        }

        public async Task AddSale(Sale sale)
        {
            await _saleRepository.Add(sale);
        }

        public async Task UpdateSale(Sale sale)
        {
            await _saleRepository.Update(sale);
        }

        public async Task DeleteSale(int id)
        {
            await _saleRepository.Delete(id);
        }

        public async Task<string> GenerateSaleReport()
        {
            string jsonReport;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Sales";
                var sales = await db.QueryAsync<Sale>(query);
                jsonReport = JsonConvert.SerializeObject(sales);
                
                var parameters = new
                {
                    ReportData = jsonReport,
                    CreatedDate = DateTime.Now
                };
    
                await db.ExecuteAsync("sp_SaveReport", parameters, commandType: CommandType.StoredProcedure);
            }
    
            return jsonReport;
        }
    }
}
