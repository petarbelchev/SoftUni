using HouseRentingSystem.Services.Statistics;
using HouseRentingSystem.Services.Statistics.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Web.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsApiController(IStatisticsService statisticsService)
            => this.statisticsService = statisticsService;

        [HttpGet]
        public StatisticsServiceModel Get()
            => statisticsService.Total();
    }
}
