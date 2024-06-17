using LeMail.Application.Dto_s.Review.Requests;
using LeMail.Application.Dto_s.Reviewer.Requests;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeMail.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        /// <summary>
        /// User service
        /// </summary>
        private readonly IReviewerService _reviewerService;

        public ReviewerController(IReviewerService reviewerService)
        {
            _reviewerService = reviewerService;
        }
        /// <summary>
        /// Create user query
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewerRequest request, CancellationToken cancellationToken)
        {
            var response = await _reviewerService.CreateAsync(request, cancellationToken);
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
            var response = await _reviewerService.GetByIdAsync(id, cancellationToken);
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
        public async Task<IActionResult> Update(UpdateReviewerRequest request, CancellationToken cancellationToken)
        {

            var response = await _reviewerService.UpdateAsync(request, cancellationToken);
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
            var result = await _reviewerService.DeleteByIdAsync(id, cancellationToken);
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
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _reviewerService.GetAllAsync(cancellationToken);
            return Ok(response);
        }
    }
}
