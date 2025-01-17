using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleSummary.Api.Services.VehicleSummary;

namespace VehicleSummary.Api.Controllers
{
    public class VehicleChecksController : Controller
    {
        private readonly IVehicleSummaryService _vehicleSummaryService;

        public VehicleChecksController(IVehicleSummaryService vehicleSummaryService)
        {
            _vehicleSummaryService = vehicleSummaryService;
        }

        // GET
        /// <summary>
        /// Get Vehicle Summary.
        /// </summary>
        /// <param name="make"></param>
        /// <returns>Vehicle models and their no of available years</returns>
        [HttpGet]
        [Route("/vehicle-checks/makes/{make}")]
        public async Task<IActionResult> Makes(string make)
        {
            var response = await _vehicleSummaryService.GetSummaryByMake(make);
            return Ok(response);
        }
    }
}