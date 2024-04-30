using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
namespace LeMail.WebApi.Controllers;
/// <summary>
/// User api controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    /// <summary>
    /// User service
    /// </summary>
    private readonly IUserService _userService;

    public UserController(IUserService userService) 
    {
        _userService = userService;
    }
    /// <summary>
    /// Create user query
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.CreateUserAsync(request, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// get user by id query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _userService.GetUserByIdAsync(id, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }
    /// <summary>
    /// update user by id query
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken)
    {

        var response = await _userService.UpdateUserAsync(request, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }
    /// <summary>
    /// Delete User by id query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]//done
    public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        var result = await _userService.DeleteUserByIdAsync(id, cancellationToken);
        if (!result)
            return NotFound();
        return NoContent();
    }
    /// <summary>
    /// Get all users query
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var response = await _userService.GetAllUsersAsync(cancellationToken);
        return Ok(response);
    }
}