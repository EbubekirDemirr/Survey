using AutoMapper;
using DataAccess.Abstract;
using Entities.Concrete.Constants;
using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class UserRepository : IUserRepository
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public UserRepository(UserManager<User> userManager, IMapper mapper, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
    }

    public List<UserViewModel> GetAll()
    {
        List<User> users = _userManager.Users.AsNoTracking().ToList<User>();
        return _mapper.Map<List<UserViewModel>>(users);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<User> GetById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<IdentityResult> CreateAsync(User entity)
    {
        entity.UserName = entity.FirstName + entity.LastName + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
        var result = await _userManager.CreateAsync(entity);

        if (!await _roleManager.RoleExistsAsync(UserRoles.UnRegisteredUser))
            await _roleManager.CreateAsync(new AppRole(UserRoles.UnRegisteredUser));

        var user = await _userManager.FindByNameAsync(entity.UserName);

        await _userManager.AddToRoleAsync(user, UserRoles.UnRegisteredUser);

        return result;
    }
    public async Task<IdentityResult> CreateAsync(User entity, string password)
    {

        entity.UserName = entity.FirstName + entity.LastName + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
        var result = await _userManager.CreateAsync(entity, password);

        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new AppRole(UserRoles.User));

        var user= await GetByEmail(entity.Email);

        await _userManager.AddToRoleAsync(user,UserRoles.User);

        return result;
    }
}
