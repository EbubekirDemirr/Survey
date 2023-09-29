using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    readonly RoleManager<AppRole> _roleManager;
    readonly UserManager<User> _userManager;
    public RoleController(RoleManager<AppRole> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    [HttpPost("create-or-update")]
    public async Task<IActionResult> CreateRole(CreateRoleModel model)
    {
        IdentityResult result = null;
        if (model.Id != null)
        {
            AppRole role = await _roleManager.FindByIdAsync(model.Id);
            role.Name = model.Name;
            result = await _roleManager.UpdateAsync(role);
        }
        else
            result = await _roleManager.CreateAsync(new AppRole { Name = model.Name, CreatedDate = DateTime.Now });

        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteRole(string id)
    {
        AppRole role = await _roleManager.FindByIdAsync(id);
        IdentityResult result = await _roleManager.DeleteAsync(role);
        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest();
    }
    
    [HttpPost("role-assign")]
    public async Task<ActionResult> RoleAssign(List<RoleAssignViewModel> modelList, string email)
    {
        User user = await _userManager.FindByEmailAsync(email);
        foreach (RoleAssignViewModel role in modelList)
        {
            if (role.HasAssign)
                await _userManager.AddToRoleAsync(user, role.RoleName);
            else
                await _userManager.RemoveFromRoleAsync(user, role.RoleName);
        }
        return Ok();
    }
}
