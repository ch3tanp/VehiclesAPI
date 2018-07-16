using API.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace API.Tests.Core.Entities
{
    public class VehicleEntityTests
    {
        //Test cases for VehicalEntity
        [Fact]
        public void ValidateYearRange()
        {
            var vehicle = new Vehicle
            {
                Year = 3010,
                Make = "Tesla",
                Model = "Model 3"
            };
            Assert.True(ValidateModel(vehicle).Count > 0);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }


}
