using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetDDD.Domain;

namespace AspNetDDD.Domain.Interfaces.Service
{
    public interface IUserService
    {

        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int id);
        Task<UserViewModel> Create(UserViewModel entity);
        Task<UserViewModel> Update(UserViewModel entity);
        Task Delete(int id);

    }
}