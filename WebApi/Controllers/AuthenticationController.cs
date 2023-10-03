using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    public IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        this._authenticationService = authenticationService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("Admin")]
    public IActionResult Admin()
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // userId'yi kullanarak ilgili işlemleri gerçekleştir
        return Ok("Bu API metodu korumalıdır.");
    }

    [Authorize(Roles = "User")]
    [HttpGet("User")]
    public IActionResult User()
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // userId'yi kullanarak ilgili işlemleri gerçekleştir
        return Ok("Bu API metodu korumalıdır.");
    }

    [Authorize(Roles = "UnRegisteredUser")]
    [HttpGet("UnRegisteredUser")]
    public IActionResult UnRegisteredUser()
    {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // userId'yi kullanarak ilgili işlemleri gerçekleştir
        return Ok("Bu API metodu korumalıdır.");
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IDataResult<LoginResultDto>> Login([FromBody] LoginViewModel model)
    {
        return await _authenticationService.Login(model);
    }

}
