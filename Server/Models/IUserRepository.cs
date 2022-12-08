using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface IUserRepository
    { 
        User GetUser(int userid);
        void PostUser(User user);
        void PutUser(User user);
        void DeleteUser(int userid);
    }
}
