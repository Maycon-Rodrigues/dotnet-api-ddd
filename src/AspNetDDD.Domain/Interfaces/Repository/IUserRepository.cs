using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetDDD.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(User entity);
        Task<User> Update(User entity);
        Task Delete(int id);

    }
}