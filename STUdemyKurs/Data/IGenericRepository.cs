using STUdemyKurs.Models;

namespace STUdemyKurs.Data
{
    public interface IGenericRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int id);

    }
}
