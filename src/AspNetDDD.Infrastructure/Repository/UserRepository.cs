using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetDDD.Domain;
using AspNetDDD.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace AspNetDDD.Infrastructure
{
    public class UserRepository : IUserRepository
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
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id.Equals(entity.Id));
            _context.Entry(user).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id.Equals(id));
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
