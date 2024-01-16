using Maggie.Dto;

namespace Maggie.App.Interfaces;

public interface IUserAppService
{
    Task<UserDto> AddUser(UserDto obj);

    Task<UserDto> GetUserById(string id);

    Task<IEnumerable<UserDto>> GetAllUsers();

    Task UpdateUser(UserDto obj);

    Task RemoveUser(UserDto obj);
}