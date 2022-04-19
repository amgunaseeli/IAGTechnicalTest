using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using RestSharp;
using VehicleSummary.Api.Model;


namespace VehicleSummary.Api.Services.VehicleSummary

{
    public interface IVehicleSummaryService
    {
        Task<VehicleSummaryResponse> GetSummaryByMake(string make);
    }
    public class VehicleSummaryService : IVehicleSummaryService
    {
        private static string BASE_URL = "https://api.iag.co.nz/vehicles/vehicletypes/makes/";
        private static string HEADER_SUBSCRIPTION_KEY = "Ocp-Apim-Subscription-Key";
        private static string HEADER_SUBSCRIPTION_KEY_VALUE = "72ec78fb999e43be8dbdac94d7236cae";

        public RestClient RestClient { get; set; }
        public VehicleSummaryService()
        {
            RestClient = new RestClient(BASE_URL)
            .AddDefaultHeader(HEADER_SUBSCRIPTION_KEY, HEADER_SUBSCRIPTION_KEY_VALUE);
        }

        public async Task<VehicleSummaryResponse> GetSummaryByMake(string make)
        {
            VehicleSummaryResponse response = new VehicleSummaryResponse();
            response.Make = make;
            response.Models = new List<VehicleSummaryModels>();
            List<string> models = await getModels(make);
            foreach (string model in models)
            {
                VehicleSummaryModels vehicleSummaryModel = await getVehicleModelYearsSummary(make, model);
                response.Models.Add(vehicleSummaryModel);
            }

            return response;
        }
        private async Task<List<string>> getModels(string make)
        {
            string modelsUrl = "{make}/models";
            RestRequest request = new RestRequest(modelsUrl, Method.Get)
            .AddUrlSegment("make", make)
            .AddQueryParameter("api-version", "v1");
            var response = await RestClient.GetAsync<List<string>>(request);
            return response;
        }
        private async Task<VehicleSummaryModels> getVehicleModelYearsSummary(string make, string model)
        {
            VehicleSummaryModels vehicleSummaryModel = new VehicleSummaryModels();
            string yearsAvailableUrl = "{make}/models/{model}/years";
            RestRequest request = new RestRequest(yearsAvailableUrl, Method.Get)
            .AddUrlSegment("make", make)
            .AddUrlSegment("model", model)
            .AddQueryParameter("api-version", "v1"); ;
            var response = await RestClient.GetAsync<List<int>>(request);
            vehicleSummaryModel.Name = model;
            vehicleSummaryModel.YearsAvailable = response.Count();
            return vehicleSummaryModel;
        }

    }
}
