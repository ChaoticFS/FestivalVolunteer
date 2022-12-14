using FestivalVolunteer.Shared.Models;

namespace FestivalVolunteer.Client.Services
{
    public interface IUserService
    {
        Task<User> GetUser(int userid);
        Task<int> PostUser(User user);
        Task PutUser(User user);
        Task DeleteUser(int userid);
    }
}
