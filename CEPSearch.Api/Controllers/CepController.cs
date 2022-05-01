using Microsoft.AspNetCore.Mvc;

namespace CEPSearch.Api.Controllers
{
    [ApiController]
    [Route("[cep]")]
    public class CepController : ControllerBase
    {
        private readonly ILogger<CepController> _logger;
        public CepController(ILogger<CepController> logger)
        {
            _logger = logger;
        }

        [HttpGet("cep/{cep}/address")]
        public async Task<IActionResult> GetCep(string cep)
        {
            return Ok(cep);
        }
    }
}
