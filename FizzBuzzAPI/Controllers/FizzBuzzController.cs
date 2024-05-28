using FizzBuzzAPI.Interfaces;
using FizzBuzzAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FizzBuzzAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzServiceFactory _serviceFactory;

        public FizzBuzzController(IFizzBuzzServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string[] values)
        {
            List<FizzBuzzResponse> responseList = new();
            try
            {
                var fizzBuzzService = _serviceFactory.CreateService();
                responseList = fizzBuzzService.GetFizzBuzzListOfValues(values);
                return Ok(responseList);
            }
            catch (Exception)
            {
                return responseList.Count == 0 ? StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error") : Ok(responseList);
            }
        }
    }


}
