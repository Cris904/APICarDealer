using CarDealershipAPI.Models;
using CarDealershipAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IEnumerable<Sale>> Get()
        {
            return await _saleService.GetAllSales();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> Get(int id)
        {
            var sale = await _saleService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound();
            }
            return sale;
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> Post([FromBody] Sale sale)
        {
            // Validar que el modelo está correcto
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _saleService.AddSale(sale);
            return CreatedAtAction(nameof(Get), new { id = sale.Id }, sale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            // Validar que el modelo está correcto
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _saleService.UpdateSale(sale);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _saleService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound();
            }

            await _saleService.DeleteSale(id);
            return NoContent();
        }

        [HttpGet("report")]
        public async Task<ActionResult<string>> GetSalesReport()
        {
            var report = await _saleService.GenerateSaleReport();
            return Ok(report);
        }
    }
}
