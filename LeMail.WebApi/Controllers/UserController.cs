using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Dto_s.User.Responses;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//TODO: сделать кастомные коды ошибок
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
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var response = await _userService.GetUserByIdAsync(id, HttpContext.RequestAborted);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpPut] //done
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
    {

        var response = await _userService.UpdateUserAsync(request, HttpContext.RequestAborted);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpDelete("{id}")]//done
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var result = await _userService.DeleteUserByIdAsync(id, HttpContext.RequestAborted);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpGet]//done
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _userService.GetAllUsersAsync(HttpContext.RequestAborted);
        return Ok(response);
    }
}