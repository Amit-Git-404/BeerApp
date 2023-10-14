using BeerApp.Contracts.IServices;
using BeerApp.Contracts.Models;
using BeerApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBeerFetchService _beerFetchService;

        public HomeController(IBeerFetchService beerFetchService)
        {
            _beerFetchService = beerFetchService ?? throw new ArgumentNullException(nameof(beerFetchService));
        }

        [HttpGet]
        [Route("GetBeers")]
        public async Task<IActionResult> GetBeersAsync([FromQuery] RequestParams reqParams)
        {
            try
            {
                string beersData = await _beerFetchService.GetBeersAsync(reqParams);
                return Ok(beersData);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
