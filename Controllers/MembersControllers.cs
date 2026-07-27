using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class MembersController(AppDBContext context) : BaseApiController
{


    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
    {
        var users = await context.Users.ToListAsync();
        return Ok(users);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetMember(string Id)
    {
        var user = await context.Users.FindAsync(Id);
        return Ok(user);
    }
}