using CursorTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursorTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(Array.Empty<User>());
    }

    [HttpGet("{id:int}")]
    public ActionResult<User> GetUser(int id)
    {
        return NotFound();
    }

    [HttpPost]
    public ActionResult<User> AddUser([FromBody] User user)
    {
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        return NoContent();
    }
}
