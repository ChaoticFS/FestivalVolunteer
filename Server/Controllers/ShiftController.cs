using FestivalVolunteer.Client;
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
            Console.WriteLine(parameters);
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

        [HttpGet("usershift/getusers")]
        public List<UserShift> GetAllUsersForShift(int shiftid)
        {
            return Repository.GetAllUsersForShift(shiftid);
        }

        [HttpGet("usershift")]
        public bool GetUserShift(string usershift)
        {
            UserShift userShift = JsonSerializer.Deserialize<UserShift>(usershift);
            return Repository.GetUserShift(userShift.UserId, userShift.ShiftId);
        }
        
        [HttpGet("usershift/getall")]
        public List<Shift> GetAllShiftsForUser(int userid)
        {
            return Repository.GetAllShiftsForUser(userid);
        }

        [HttpGet("usershift/getcount")]
        public int GetUserShiftCount(int shiftid) 
        {
            return Repository.GetUserShiftCount(shiftid);
        }

        [HttpPost("usershift")]
        public void PostUserToShift(UserShift userShift)
        {
            Repository.PostUserToShift(userShift);
        }

        [HttpDelete("usershift")]
        public void DeleteUserShift(string usershift)
        {
            UserShift userShift = JsonSerializer.Deserialize<UserShift>(usershift);
            Repository.DeleteUserShift(userShift.UserId, userShift.ShiftId);
        }
    }
}
