using FestivalVolunteer.Server.Models;
using FestivalVolunteer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace FestivalVolunteer.Server.Controllers
{
    [ApiController]
    [Route("api/shift")]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftRepository Repository = new ShiftRepository();
        public ShiftController(IShiftRepository shiftRepository)
        {
            if (Repository == null && shiftRepository != null)
            {
                Repository = shiftRepository;
                Console.WriteLine("Repository initialized");
            }
        }

        [HttpGet("filter")]
        public IEnumerable<Shift>? GetFilteredShifts(string parameters)
        {
            Filter? filter = JsonSerializer.Deserialize<Filter>(parameters);
            Console.WriteLine(filter);
            return Repository.GetFilteredShifts(filter);
        }

        [HttpGet]
        public Shift GetShift(int shiftid)
        {
            return Repository.GetShift(shiftid);
        }

        [HttpPost]
        public void PostShift(Shift shift)
        {
            Repository.PostShift(shift);
        }

        [HttpPut]
        public void PutShift(Shift shift)
        {
            Repository.PutShift(shift);
        }

        [HttpDelete]
        public void DeleteShift(int shiftid)
        {
            Repository.DeleteShift(shiftid);
        }
    }
}
