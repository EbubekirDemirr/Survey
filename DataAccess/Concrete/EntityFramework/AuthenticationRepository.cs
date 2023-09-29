using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Constants;
using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class AuthenticationRepository : IAuthenticationServiceRepository
{
    public ProjectDbContext _context { get; set; }
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _userManager;

    public AuthenticationRepository(ProjectDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    private string generateJwtToken(User user)
    {
        var userRoleIds = _context.UserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
        var userRoleNames = _context.Roles.Where(x => userRoleIds.Contains(x.Id)).Select(x => x.Name).ToList();


        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var Secret = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JWT")["Secret"];
        var key = Encoding.ASCII.GetBytes(Secret);

        List<Claim> claims = new List<Claim>()
        {
            new Claim( ClaimTypes.Name, user.FirstName??"X".ToString() +" "+ user.LastName??"X".ToString() ),
            new Claim(ClaimTypes.UserData, user.Id.ToString() ?? "1"),
        };
        userRoleNames.ForEach(x=> claims.Add(new Claim(ClaimTypes.Role, x)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = "JwtTokenWithIdentity",
            Issuer = "JwtTokenWithIdentity",
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public LoginResultDto GetToken(LoginViewModel login)
    {
        User dbUser = (User)_context.Set<User>().AsNoTracking().FirstOrDefault(x => x.Email.Equals(login.Email));
        string tokenInfo = CreateAccessToken(dbUser);

        RefreshToken refreshToken = GetRefreshToken();
        SetRefreshToken(refreshToken, dbUser);

        return new LoginResultDto() { Token = tokenInfo, UserId = dbUser.Id };

    }


    protected string CreateAccessToken(User dbUser)
    {
        IdentityUserToken<long> userTokens = new IdentityUserToken<long>();
        string tokenInfo;
        if (_context.AspNetUserTokens.Count(x => x.UserId == dbUser.Id) > 0)
        {
            //İlgili token bilgileri bulunur.
            userTokens = _context.AspNetUserTokens.FirstOrDefault(x => x.UserId == dbUser.Id);

            //Expire olmuş ise yeni token oluşturup günceller.

            //Create new token
            tokenInfo = generateJwtToken(dbUser);
            userTokens.Value = tokenInfo;
            _context.AspNetUserTokens.Update(userTokens);
            _context.SaveChanges();

        }
        else
        {
            //Create new token
            tokenInfo = generateJwtToken(dbUser);
            userTokens.UserId = dbUser.Id;
            userTokens.LoginProvider = "SystemAPI";
            userTokens.Name = dbUser.FirstName ?? "X";
            userTokens.Value = tokenInfo;

            //Save Toke
            _context.AspNetUserTokens.Add(userTokens);
            _context.SaveChanges();


        }
        return tokenInfo;
    }

    protected RefreshToken GetRefreshToken()
    {
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.Now.AddDays(10),
            Created = DateTime.Now
        };
        return refreshToken;
    }

    private void SetRefreshToken(RefreshToken refreshToken, User user)
    {
        var cookieOptions = new CookieOptions
        {
            //HttpOnly= false,
            Expires = refreshToken.Expires,
        };

        user.RefreshToken = refreshToken.Token;
        user.TokenCreatedDate = refreshToken.Created;
        user.TokenExpires = refreshToken.Expires;
        _context.SaveChanges();

        _context.Entry(user).State = EntityState.Modified;
        _context.Set<User>().Update(user);

        //_context.Set<User>.Update(user);
        // IdentityResult result = _userManager.UpdateAsync(user).Result;

        _context.SaveChanges();
        _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
    }

    public LoginResultDto RefreshToken()
    {
        var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refreshToken"];
        User user = (User)_context.Set<User>().AsNoTracking().FirstOrDefault(x => x.Id.Equals(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.UserData)));

        if (user != null)
        {
            if (!user.RefreshToken.Equals(refreshToken))
            {
                return new LoginResultDto() { Token = "Invalid Refresh Token." };
            }
            else if (user.TokenExpires > DateTime.Now)
            {
                return new LoginResultDto() { Token = "Token expired." };
            }
        }


        string token = CreateAccessToken(user);
        var newRefreshToken = GetRefreshToken();
        SetRefreshToken(newRefreshToken, user);
        return new LoginResultDto() { Token = token, UserId = user.Id };
    }
}
