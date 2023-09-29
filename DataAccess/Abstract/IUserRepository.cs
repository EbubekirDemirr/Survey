using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Abstract;

public interface IUserRepository
{
    List<UserViewModel> GetAll();
    Task<User?> GetByEmail(string email);
    Task<User> GetById(string id);

    Task<IdentityResult> CreateAsync(User entity);
    Task<IdentityResult> CreateAsync(User entity, string password);
}
