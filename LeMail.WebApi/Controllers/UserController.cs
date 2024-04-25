using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
namespace LeMail.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) 
    {
        _userService = userService;
    }

    [HttpPost] // done
    public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.CreateUserAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")] // done
    public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _userService.GetUserByIdAsync(id, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpPut] //done
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken)
    {

        var response = await _userService.UpdateUserAsync(request, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpDelete("{id}")]//done
    public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        var result = await _userService.DeleteUserByIdAsync(id, cancellationToken);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpGet]//done
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var response = await _userService.GetAllUsersAsync(cancellationToken);
        return Ok(response);
    }
}