using Microsoft.AspNetCore.Mvc;

namespace user_api.Controllers;

[ApiController]
[Route("")]

public class Default : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("GET--to get all users '/user'\n"+
            "GET--to get specific user using id '/user/:id'\n"+
            "GET--to get just the list of friends '/user/:id/friends\n"+
            "POST--to add a user '/user + body request'\n"+
            "PUT--to edit the info of users (except friends) '/user/:id/ + body request'\n"+
            "DELETE--to delete the user based on its id 'user/:id + delete request'\n");
    }
}