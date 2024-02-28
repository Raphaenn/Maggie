using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces.Repository;
using Maggie.Dto;
using Maggie.App.Interfaces;

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
        Guid newId = Guid.NewGuid();
        Users user = new Users(id: newId, name: obj.Nome, email: obj.Email, obj.Cpf);

        if (await _userRepository.CheckEmailUsage(obj.Email))
        {
            throw new InvalidOperationException("Email already in use.");
        }
        
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