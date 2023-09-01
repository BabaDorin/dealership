using DealershipManager.Dtos;
using DealershipManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipManager.Controllers
{
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost] // POST api/sales
        [Route("sales")]
        public IActionResult Add(AddSaleDto sale)
        {
            _saleService.Add(sale);

            return Ok();
        }

        [HttpGet]
        [Route("sales")]
        public IActionResult GetAll(DateTime startDate, DateTime endDate)
        {
            var result = _saleService.GetAll(startDate, endDate);

            return Ok(result);
        }
    }
}
