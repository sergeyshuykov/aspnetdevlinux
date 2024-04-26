using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Services;
using MyModels;
using Microsoft.AspNetCore.Authentication;

namespace WebMVC.Controllers;

public class SecuredController : Controller
{
    private ApplicationContext db;
    public SecuredController(ApplicationContext db) => this.db = db;

    //[AllowAnonymous]
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Login()
    {
        //this.User.Identity.Name
        //this.User.IsInRole

        //this.User.Identity.AuthenticationType
        return View();

        /*var claims = new List<Claim> {new Claim (ClaimTypes.Name, username)};
        ClaimsIdentity ci = new ClaimsIdentity(claims, "Cookies");

        this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(ci));*/
    }

    
    [HttpPost]
    [Route("/login")]
    public IActionResult GetJWT([FromBody] LoginModel m)
    {
        // verify user data
        var user = db.Person.Where(p=>p.Name == m.Login && p.Password == m.Password).SingleOrDefault();
        if (user == null)
            return this.NotFound();

        var claims = new List<Claim>{ new Claim(ClaimTypes.Name, m.Login)};
        //claim.Add(new Claim(ClaimTypes.))
        var jwt = new JwtSecurityToken(
            issuer      : MyAuthOptions.ISSUER,
            audience    : MyAuthOptions.AUDIENCE,
            claims      : claims,
            expires     : DateTime.UtcNow.AddHours(1),
            signingCredentials : new SigningCredentials(
                MyAuthOptions.GetKey(),
                SecurityAlgorithms.HmacSha256)
        );
        return this.Json(new { JwtToken = new JwtSecurityTokenHandler().WriteToken(jwt)});

    }

}