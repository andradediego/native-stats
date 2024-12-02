using Microsoft.AspNetCore.Mvc;
using NativeStats.DTO;
using NativeStats.Middleware;
using NativeStats.Service;


namespace NativeStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [MobileOnly]
        public async Task<IActionResult> Index()
        {
            var service = new ApiService(true, _httpClientFactory);
            var data = await service.CallFootballServiceAsync();
            
            if (!data.Any())
            {
                _logger.LogWarning("No data returned for recent matches.");
            }

            return View(data);
        }

        public IActionResult NotMobile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FootballLeagueCarousel(bool isRecent = false)
        {
            try
            {
                var service = new ApiService(isRecent, _httpClientFactory);
                var data = await service.CallFootballServiceAsync();

                return PartialView("_Carousel", data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching data for FootballLeagueCarousel.");
                return PartialView("_Carousel", new List<MatchesByAreaDTO>());
            }
        }
    }
}
