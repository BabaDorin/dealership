using DealershipManager.Dtos;
using DealershipManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace DealershipManager.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost] // POST api/clients
        [Route("clients")]
        public IActionResult Add(AddClientDto client)
        {
            _clientService.Add(client);

            return Ok();
        }

        [HttpGet] // GET api/clients
        [Route("clients")]
        public IActionResult GetAll()
        {
            var result = _clientService.GetAll();

            return Ok(result);
        }
    }
}
