using EntityFrameworkTest.Models;
using EntityFrameworkTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkTest.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet(Name = "users")]
    public ActionResult<List<User>> GetUsers()
    {
        return _usersService.GetUsers();
    }


    [HttpPut(Name = "user")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> UpdateUser([FromBody] User user)
    {
        try
        {
            var userUpdated = _usersService.UpdateUser(user);
            return userUpdated;
        }
        catch (InvalidOperationException exception)
        {
            return new NotFoundResult();
        }
    }
}