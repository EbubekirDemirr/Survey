using Core.Utilities.Results;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Identity;

namespace Business.Abstract;

public interface IUserService
{
    Task<IDataResult<IdentityResult>> CreateAsync(CreateUserModel model);

    Task<IDataResult<UserViewModel>> GetByEmailAsync(string email);

    Task<IDataResult<UserViewModel>> GetByIdEntityAsync(string id);
}
