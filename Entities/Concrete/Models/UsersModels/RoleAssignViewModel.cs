namespace Entities.Concrete.Models.UsersModels;

public class RoleAssignViewModel
{
    public long RoleId { get; set; }
    public string RoleName { get; set; }
    public bool HasAssign { get; set; } // o anki rolün ilgili kullanıcıya atanıp atanmadığı bilgisi(HasAssign) 
}
