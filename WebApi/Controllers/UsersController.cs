using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    readonly SignInManager<User> _signInManager;
    readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    IHttpContextAccessor _contextAccessor;

    public UsersController(IUserService userService, SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _userService = userService;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost()]
    [Route("create-user")]
    public async Task<ActionResult<IDataResult<IdentityResult>>> CreateEntityAsync([FromBody] CreateUserModel model)
    {
        var result = await _userService.CreateAsync(model);
        //Role Manager ile role eklemeyi unutma
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-user-by-email")]
    public async Task<ActionResult<IDataResult<UserViewModel>>> GetByEmailAsync()
    {
        //var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
        //var claims = HttpContext.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
        //var email = claims.Value;
        var result = await _userService.GetByEmailAsync("KAANDOGAN234@HOTMAIL.COM");

        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
