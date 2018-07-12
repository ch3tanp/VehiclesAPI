using API.Core.Entities;
using API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Infrastructure.Data
{
   public  class VehicleRepository :EfRepository<Vehicle> , IVehicleRepository
    {
        public VehicleRepository(AppDbContext dbContext) :base(dbContext)
        {                
        }
    }
}
