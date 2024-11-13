using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")] //  to access this the user can write e.g localhost5001/api/users  
public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() // takes the list of users from the web app
    {
        var users = await context.Users.ToListAsync(); 

        return users;   // we can return all kinds of return types such as return badrequest etc. bcz we are using "ActionResult" above
    }

    [HttpGet("{id:int}")] 
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();

        return user;
    }
}
