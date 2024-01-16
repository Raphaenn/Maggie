using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces;
using Maggie.Domain.Interfaces.Repository;
using Maggie.Dto;
using Maggie.App.Interfaces;
using Maggie.App.Mapper;

namespace Maggie.App.Services;

public class UserAppService : IUserAppService
{

    private readonly IUserRepository _userRepository;
    
    public UserAppService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserDto> AddUser(UserDto obj)
    {
        Users user = new Users(id: obj.Id, name: obj.Nome, email: obj.Email,
            birthdate: obj.DataNascimento, status: obj.Status);
        
        
        await _userRepository.Add(user);
        return obj;
    }

    public Task<UserDto> GetUserById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser(UserDto obj)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUser(UserDto obj)
    {
        throw new NotImplementedException();
    }
}