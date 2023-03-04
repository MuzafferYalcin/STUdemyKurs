using Microsoft.EntityFrameworkCore;
using STUdemyKurs.Models;

namespace STUdemyKurs.Data
{
    public class GenericRepository : IGenericRepository
    {
        readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(i=> i.Images).SingleOrDefaultAsync(x=> x.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users =await _context.Users.Include(_x => _x.Images).ToListAsync();
            return users;
        }
    }
}
