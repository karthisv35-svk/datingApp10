using API.Entities;
using API.Interfaces;

namespace API.Extensions;

public static class AppUserExtensions
{
    public static UserDto ToDtos(this AppUser user,ITokenService tokenService)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Displayname = user.Displayname,
            Token = tokenService.CreateToken(user)
        };
    }
}