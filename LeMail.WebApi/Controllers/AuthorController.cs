using LeMail.Application.Dto_s.Author.Requests;
using LeMail.Application.Dto_s.Review.Requests;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeMail.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        /// <summary>
        /// User service
        /// </summary>
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        /// <summary>
        /// Create user query
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorRequest request, CancellationToken cancellationToken)
        {
            var response = await _authorService.CreateAsync(request, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// get user by id query
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _authorService.GetByIdAsync(id, cancellationToken);
            if (response is null)
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
        public async Task<IActionResult> Update(UpdateAuthorRequest request, CancellationToken cancellationToken)
        {

            var response = await _authorService.UpdateAsync(request, cancellationToken);
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
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _authorService.DeleteByIdAsync(id, cancellationToken);
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
        public async Task<IActionResult> GetAll(int pageNumber , int pageSize , CancellationToken cancellationToken)
        {
            var response = await _authorService.GetAllAsync(cancellationToken);
    
            var paginatedResponse = response.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
    
            return Ok(paginatedResponse);
        }

    }
}
