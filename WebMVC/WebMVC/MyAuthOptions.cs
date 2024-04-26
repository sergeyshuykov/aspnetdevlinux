using System.Text;
using Microsoft.IdentityModel.Tokens;

public class MyAuthOptions
{
    public const string ISSUER = "myserver.domain.name";
    public const string AUDIENCE = "WebApplication.JS";

    const string KEY = "my password845432dsfkjlgfdjdsf9043285sejfk1890qwnejdmn,mdsnas085ql4j5qlkw";

    public static SymmetricSecurityKey GetKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}