using Core.Utilities.Results;
using Entities.Concrete.Models.UsersModels;

namespace Business.Abstract;

public interface IAuthenticationService
{
    IDataResult<LoginResultDto> Login(LoginViewModel login);
    IDataResult<LoginResultDto> RefreshToken();
}
