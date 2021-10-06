using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    public interface IVehicleRepository
    {
        List<Vehicle> Get();
        Vehicle Get(int id);
    }

    public class FakeVehicleRepository : IVehicleRepository
    {
        private List<Vehicle> vehicles;

        public FakeVehicleRepository()
        {
            this.vehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Name ="Vehicle 1", Model = "Model 1"},
                new Vehicle { Id = 2, Name ="Vehicle 2", Model = "Model 2"},
                new Vehicle { Id = 3, Name ="Vehicle 3", Model = "Model 3"},
                new Vehicle { Id = 4, Name ="Vehicle 4", Model = "Model 4"},
                new Vehicle { Id = 5, Name ="Vehicle 5", Model = "Model 5"},
            };
        }

        public List<Vehicle> Get()
        {
            return vehicles;
        }

        public Vehicle Get(int id)
        {
            return vehicles.SingleOrDefault(v => v.Id == id);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehiclesContext context;

        private IVehicleRepository vehicleRepository;

        //public VehiclesController()
        //    : this(new FakeVehicleRepository())
        //{

        //}

        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var vehicles = vehicleRepository.Get();

            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Vehicle vehicle = vehicleRepository.Get(id);

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var vehicle = context.Vehicles.Find(id);
            context.Vehicles.Remove(vehicle);
            context.SaveChanges();
            return RedirectToAction("Vehicles");
        }
    }
}
