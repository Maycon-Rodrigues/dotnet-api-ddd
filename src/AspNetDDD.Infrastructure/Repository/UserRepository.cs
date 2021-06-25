using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetDDD.Domain;
using Microsoft.EntityFrameworkCore;

namespace AspNetDDD.Infrastructure
{
    public class UserRepository : IRepository<User>
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext mySqlContext)
        {
            _context = mySqlContext;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Id.Equals(id));
        }

        public async Task<User> Create(User entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Update(User entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            _context.Remove(id);
        }
    }
}
