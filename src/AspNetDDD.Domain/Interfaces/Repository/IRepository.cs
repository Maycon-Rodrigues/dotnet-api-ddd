using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetDDD.Domain
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        void Delete(int id);
    }
}
