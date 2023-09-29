
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete.DbEntities.Users;

public class AppRole : IdentityRole<long>
{
    public AppRole()
    {
        
    }
    public AppRole(string roleName) :base(roleName)
    {
        
    }
    public DateTime CreatedDate { get; set; }
}
