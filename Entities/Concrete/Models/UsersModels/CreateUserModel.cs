using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete.Models.UsersModels;

public class CreateUserModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }

    public string? Password { get; set; }
}
