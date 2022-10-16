using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProcurementManagerUltimate.Model;

public class AuthHelper
{
    private readonly IList<Claim> Claims;
    private readonly AppFeatures App;

    public AuthHelper(IList<Claim> claims, AppFeatures app)
    {
        Claims = claims;
        App = app;
    }
    public string Key
    {
        get
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(App.RandomKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: App.Issuer,
                audience: App.Audience,
                claims: Claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
