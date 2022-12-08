using FestivalVolunteer.Server.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
