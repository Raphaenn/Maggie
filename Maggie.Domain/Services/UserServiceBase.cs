using Maggie.Domain.Entities;
using Maggie.Domain.Interfaces.Repository;

namespace Maggie.Domain.Services;

public class UserServiceBase : ServiceBase<Users>, IUserRepository
{
   private readonly IUserRepository _userRepository;

   public UserServiceBase(IUserRepository userRepository) : base(userRepository)
   {
      _userRepository = userRepository;
   }
   
   public async Task<Users> Add(Users user)
   {
      // Lógica de negócios se necessário
      return await _userRepository.Add(user);
   }

   public async Task<IEnumerable<Users>> GetAll()
   {
      IEnumerable<Users> allUsers =  await _userRepository.GetAll();
      return allUsers;
   }

   public async Task<bool> CheckEmailUsage(string email)
   {
      return await _userRepository.CheckEmailUsage(email);
   }
}