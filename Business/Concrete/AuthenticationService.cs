using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Models.UsersModels;

namespace Business.Concrete;

public class AuthenticationService : IAuthenticationService
{
    IAuthenticationServiceRepository _authenticationServiceRepository;

    public AuthenticationService(IAuthenticationServiceRepository authenticationServiceRepository)
    {
        this._authenticationServiceRepository = authenticationServiceRepository;
    }

    public IDataResult<LoginResultDto> Login(LoginViewModel login)
    {
        try
        {

            LoginResultDto resultDto = _authenticationServiceRepository.GetToken(login);

            return new SuccessDataResult<LoginResultDto>(resultDto);
        }
        catch (Exception ex)
        {
            return new ErrorDataResult<LoginResultDto>();
        }
    }

    public IDataResult<LoginResultDto> RefreshToken()
    {
        LoginResultDto resultDto = _authenticationServiceRepository.RefreshToken();

        return new SuccessDataResult<LoginResultDto>(resultDto);
    }
}
