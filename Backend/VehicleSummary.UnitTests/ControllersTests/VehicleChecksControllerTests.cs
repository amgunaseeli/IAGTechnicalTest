using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VehicleSummary.Api.Controllers;
using VehicleSummary.Api.Model;
using VehicleSummary.Api.Services.VehicleSummary;
using Xunit;

namespace VehicleSummary.UnitTests.ControllersTests
{
    public class VehicleChecksControllerTests
    {
        private readonly VehicleChecksController controller;
        private readonly IVehicleSummaryService fakeVehicleSummaryService;

        public VehicleChecksControllerTests()
        {
            fakeVehicleSummaryService = A.Fake<IVehicleSummaryService>();
            controller = new VehicleChecksController(fakeVehicleSummaryService);
        }
        [Fact]
        public async Task Call_VehicleSummaryService_with_given_make()
        {
            var make = "Lotus";
            VehicleSummaryResponse mockVehicleSummaryResponse = new VehicleSummaryResponse();
            A.CallTo(() => fakeVehicleSummaryService.GetSummaryByMake(make))
                .Returns(mockVehicleSummaryResponse);
            var response = await controller.Makes(make);
            A.CallTo(() => fakeVehicleSummaryService.GetSummaryByMake(make))
                .MustHaveHappened();
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Call_VehicleSummaryService_BadData()
        {
            var make = "BMW";
            VehicleSummaryResponse mockVehicleSummaryResponse = new VehicleSummaryResponse();
            A.CallTo(() => fakeVehicleSummaryService.GetSummaryByMake(make))
                .Returns(mockVehicleSummaryResponse);
            var response = await controller.Makes(make);
            A.CallTo(() => fakeVehicleSummaryService.GetSummaryByMake(make))
                .MustHaveHappened();
           // Assert.NotNull(response);
           // assert bad data
        }
    }
}