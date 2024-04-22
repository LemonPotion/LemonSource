using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Dto_s.User.Responses;
using LeMail.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeMail.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest request)
        {
            var response = await _userService.CreateUserAsync(request, default); // Параметр CancellationToken можно передать при необходимости
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteUserResponse>> DeleteUser(Guid id)
        {
            var request = new DeleteUserRequest { Id = id };
            var response = await _userService.DeleteUserAsync(request, default); // Параметр CancellationToken можно передать при необходимости
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserResponse>> GetUser(Guid id)
        {
            var response = await _userService.GetUserAsync(id, default); // Параметр CancellationToken можно передать при необходимости
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateUserResponse>> UpdateUser(UpdateUserRequest request)
        {
            var response = await _userService.UpdateUserAsync(request, default); // Параметр CancellationToken можно передать при необходимости
            return Ok(response);
        }
    }
}
