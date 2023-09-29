using Entities.Concrete.Models.UsersModels;

namespace DataAccess.Abstract;

public interface IAuthenticationServiceRepository
{
    LoginResultDto GetToken(LoginViewModel login);
    LoginResultDto RefreshToken();
}
