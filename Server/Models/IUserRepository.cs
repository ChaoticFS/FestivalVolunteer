using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Server.Models
{
    public interface IUserRepository
    { 
        User GetUser(int userid);
        int PostUser(User user);
        void DeleteUser(int userid);
        void PutUser(User user);
    }
}
