using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetDDD.Domain;
using AspNetDDD.Infrastructure;
using AutoMapper;

namespace AspNetDDD.Service
{
    public class UserService : IService<UserViewModel>
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public UserService(IMapper mapper, UserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }

        public async Task<UserViewModel> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<User, UserViewModel>(user);
        }

        public Task<UserViewModel> Create(UserViewModel entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserViewModel> Update(UserViewModel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}