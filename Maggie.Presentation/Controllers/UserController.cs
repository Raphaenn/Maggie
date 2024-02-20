using Maggie.Dto;
using Maggie.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Maggie.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserAppService _userAppService;

    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpPost("/add")]
    public async Task<ActionResult<UserDto>> Add([FromBody] UserDto user)
    {
        await _userAppService.AddUser(user);
        return Ok();
    }

    [HttpGet("/list")]
    public async Task<ActionResult<IEnumerable<UserDto>>> List()
    {
        IEnumerable<UserDto> listUsers = await _userAppService.GetAllUsers();
        return Ok(listUsers.ToList());
    }
}