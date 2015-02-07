using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DD.TrafficLight.Web.Models;

namespace DD.TrafficLight.Web.Controllers
{
    public class TrafficLightConfigurationsApiController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/TrafficLightConfigurationsApi
        // For demo purposes we only care about the first one
        public TrafficLightConfiguration GetTrafficLightConfigurations()
        {
            return _db.TrafficLightConfigurations.Any() ? _db.TrafficLightConfigurations.First() : new TrafficLightConfiguration()
            {
                MaintenanceMode = true
            };
        }
    }
}