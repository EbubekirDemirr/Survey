namespace Entities.Concrete.Models.UsersModels;

public class LoginResultDto
{
    public LoginResultDto()
    {
    }

    public LoginResultDto(string token, long userId)
    {
        Token = token;
        UserId = userId;
    }

    public string Token { get; set; }
    public long UserId { get; set; }
}