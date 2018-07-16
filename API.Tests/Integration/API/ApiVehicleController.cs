using API.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace API.Tests.Integration.API
{
    public class ApiVehicleController : BaseWebTest
    {
        [Fact]
        public void ReturnsVehicleWithTwoItem()
        {
            var response = _client.GetAsync("/api/Vehicle").Result;
            response.EnsureSuccessStatusCode();
            var stringResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<Vehicle>>(stringResponse);

            Assert.True(result.Count == 2);
        }

        [Fact]
        public void Returns404GivenInvalidId()
        {
            string invalidId = "100";
            var response = _client.GetAsync($"/api/vehicle/{invalidId}").Result;
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);            
        }
    }
}
