using Microsoft.AspNetCore.Mvc;


namespace user_api.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private static List<User> users = new List<User>
    {
        new User {
            id = 1,
            firstName = "John Mark",
            lastName = "Bautista",
            friends = new List<string>(){"Alice, Bob, Chloe"}
        },
        new User {
            id = 2,
            firstName = "JV",
            lastName = "Fernandez",
            friends= new List<string>(){"Bob, Chloe"}
        }
    };
    

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = users.Find( u => u.id == id);
        if (user == null){
            return BadRequest("cannot find user with that ID");
        }
        return Ok(user);
    }

    [HttpGet("{id}/friends")]
    public async Task<IActionResult> GetFriends(int id)
    {
        var user = users.Find( u => u.id == id);
        if (user == null){
            return BadRequest("cannot find user with that ID");
        }

        var friends = user.friends;
        return Ok(friends);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(User user){
        users.Add(user);
        return Ok(users);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditUser(User request, int id){
        var user = users.Find( u => u.id == id);
        if (user == null){
            return BadRequest("cannot find user with that ID");
        }

        user.firstName = request.firstName;
        user.lastName = request.lastName;

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id){
        var user = users.Find( u => u.id == id);
        if (user == null){
            return BadRequest("cannot find user with that ID");
        }

        users.Remove(user);
        return Ok("User {id} successfully deleted");
    }
}
