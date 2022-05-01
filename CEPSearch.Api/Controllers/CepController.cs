using CEPSearch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CEPSearch.Api.Controllers
{
    [ApiController]
    [Route("[cep]")]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;
        public CepController(ILogger<CepController> logger, ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet("/cep/{cep}/address")]
        public async Task<IActionResult> GetCep(string cep)
        {
            try
            {
                var result = await _cepService.GetAddressByCep(cep);

                return Ok(result);
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Bad Request":
                        return BadRequest(new { Title = "Bad Request", StatusCode = 400 });
                    default:
                        return StatusCode(500, new { Title = "Internal Server Error", StatusCode = 500 });
                }
            }
        }
    }
}
