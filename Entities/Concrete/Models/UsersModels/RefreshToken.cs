namespace Entities.Concrete.Models.UsersModels;

public class RefreshToken
{
    public RefreshToken()
    {

    }
    public string Token { get; set; }
    public DateTime Created { get; set; }
    public DateTime Expires { get; set; }
}
