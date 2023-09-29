using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;

    IdentityResult result;

    public UserService(IUserRepository userRepository, IMapper mapper = null, UserManager<User> userManager = null)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<IDataResult<IdentityResult>> CreateAsync(CreateUserModel model)
    {
        User createdUser = _mapper.Map<User>(model);

        try
        {
            result = model.Password is null ? await _userRepository.CreateAsync(createdUser) : await _userRepository.CreateAsync(createdUser, model.Password);
        }
        catch (Exception err)
        {
            return new ErrorDataResult<IdentityResult>(result, err.Message);
        }
        return new SuccessDataResult<IdentityResult>(result);
    }

    public async Task<IDataResult<UserViewModel>> GetByEmailAsync(string email)
    {
        User user = await _userRepository.GetByEmail(email.ToUpper());
        return new SuccessDataResult<UserViewModel>(_mapper.Map<UserViewModel>(user));
    }

    public async Task<IDataResult<UserViewModel>> GetByIdEntityAsync(string id)
    {
        User user = await _userRepository.GetById(id);

        return new SuccessDataResult<UserViewModel>(_mapper.Map<UserViewModel>(user));
    }
}
