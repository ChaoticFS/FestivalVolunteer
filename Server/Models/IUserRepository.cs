using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface IUserRepository
    {
       
        Shift GetUser(int id);
        void PostUser(User user);
        void DeleteUser(int id);
        void PutUser(User user);
    }
}
