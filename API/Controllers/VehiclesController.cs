using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Core.Entities;
using API.Core.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            this._vehicleRepository = vehicleRepository;
        }

        // GET: All Vehicles
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var vehicles = _vehicleRepository.List();
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        //GET : api/Vehicles/id
        [Route("{id}", Name = "GetById")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                Vehicle result = _vehicleRepository.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // DELETE : api/Vehicles/id
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                var vehicleExists = _vehicleRepository.GetById(id);
                if (vehicleExists != null)
                {
                    _vehicleRepository.Delete(vehicleExists);
                    return Ok(string.Format("Vehicle with id {0} deleted successfully.", id));
                }
                else
                {
                    return NotFound(string.Format("Vehicle with id {0} not found", id));
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest();

            // Check for Model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    vehicle = _vehicleRepository.Add(vehicle);
                    if (vehicle == null)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        return CreatedAtRoute("GetById", new { id = vehicle.Id }, vehicle);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest();
            // Check for Model State
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    _vehicleRepository.Update(vehicle);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
        }
    }
}
