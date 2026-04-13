using Microsoft.AspNetCore.Mvc;

namespace CursorTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> Get()
    {
        var users = new[]
        {
            new UserDto { Id = 1, Name = "Alice" },
            new UserDto { Id = 2, Name = "Bob" },
        };

        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public ActionResult<UserDto> GetById(int id)
    {
        return Ok(new UserDto { Id = id, Name = $"User {id}" });
    }

    [HttpPost]
    public ActionResult<UserDto> Post([FromBody] CreateUserRequest request)
    {
        var created = new UserDto { Id = 1, Name = request.Name };
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] UpdateUserRequest request)
    {
        _ = id;
        _ = request;
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _ = id;
        return NoContent();
    }

    public record CreateUserRequest(string Name);
    public record UpdateUserRequest(string Name);
}

