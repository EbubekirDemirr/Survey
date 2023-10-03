using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete;

public class AuthenticationService : IAuthenticationService
{
    IAuthenticationServiceRepository _authenticationServiceRepository;
    private readonly UserManager<User> _userManager;

    public AuthenticationService(IAuthenticationServiceRepository authenticationServiceRepository, UserManager<User> userManager)
    {
        this._authenticationServiceRepository = authenticationServiceRepository;
        _userManager = userManager;
    }

    public async Task<IDataResult<LoginResultDto>> Login(LoginViewModel login)
    {
        var result = false;
        if (login is not null)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user != null)
            {
                result = await _userManager.CheckPasswordAsync(user, login.Password);
            }
            else
            {
                return new ErrorDataResult<LoginResultDto>("Şifreler doğğru değil");
            }
        }
        else
        {
            return new ErrorDataResult<LoginResultDto>("Model boş");
        }

        if (result)
        {
            try
            {
                LoginResultDto resultDto = _authenticationServiceRepository.GetToken(login);

                return new SuccessDataResult<LoginResultDto>(resultDto);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<LoginResultDto>(ex.Message);
            }
        }
        else
        {
            return new ErrorDataResult<LoginResultDto>("Başarısız");
        }
      
    }

    public IDataResult<LoginResultDto> RefreshToken()
    {
        LoginResultDto resultDto = _authenticationServiceRepository.RefreshToken();

        return new SuccessDataResult<LoginResultDto>(resultDto);
    }


}
