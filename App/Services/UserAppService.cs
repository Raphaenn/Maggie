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
        Users user = new Users(name: obj.Nome, email: obj.Email,
            birthdate: obj.DataNascimento, status: obj.Status, UserRole.Default, cep: obj.Cep);
        
        await _userRepository.Add(user);
        return obj;
    }

    public Task<UserDto> GetUserById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        IEnumerable<Users> allUsers = await _userRepository.GetAll();
        List<UserDto> userList = new List<UserDto>();
        foreach (Users user in allUsers)
        {
            UserDto parsedUser = new UserDto
            {
                Nome = user.Name,
                Email = user.Email,
                DataNascimento = user.BirthDate,
                Status = user.Status,
            };
            userList.Add(parsedUser);
        }
        
        return userList;
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