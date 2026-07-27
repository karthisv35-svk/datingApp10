namespace API.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
         var tokenKey = config["TokenKey"] ?? throw new InvalidOperationException("TokenKey is not configured.");

        if(tokenKey.Length < 16)
        {
            throw new InvalidOperationException("TokenKey must be at least 16 characters long.");
        }

        var ssKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenKey));

        var creds = new SigningCredentials(ssKey, SecurityAlgorithms.HmacSha512Signature);

        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id),
            new (ClaimTypes.Email, user.Email)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}