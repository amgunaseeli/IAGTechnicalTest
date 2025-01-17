using System.Collections.Generic;

namespace VehicleSummary.Api.Model
{
    public class VehicleSummaryResponse
    {
        public string Make { get; set; }
        public List<VehicleSummaryModels> Models { get; set; } = new List<VehicleSummaryModels>();
    }

    public class VehicleSummaryModels
    {
        public string Name { get; set; }
      
        public int YearsAvailable { get; set;  }
    }
}
