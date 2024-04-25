using LeMail.Application.Dto_s.Contact.Requests;
using LeMail.Application.Dto_s.Contact.Responses;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeMail.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
    
    [HttpPost] // done
    public async Task<IActionResult> CreateContact(CreateContactRequest request, CancellationToken cancellationToken)
    {
        var response = await _contactService.CreateAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")] // done
    public async Task<IActionResult> GetContactById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _contactService.GetContactByIdAsync(id, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpPut] //done
    public async Task<IActionResult> UpdateContact(UpdateContactRequest request, CancellationToken cancellationToken)
    {

        var response = await _contactService.UpdateContactAsync(request, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }

    [HttpDelete("{id}")]//done
    public async Task<IActionResult> DeleteContact(Guid id, CancellationToken cancellationToken)
    {
        var result = await _contactService.DeleteContactByIdAsync(id, cancellationToken);
        
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpGet]//done
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var response = await _contactService.GetAllContactsAsync(cancellationToken);
        return Ok(response);
    }
}