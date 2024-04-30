using LeMail.Application.Dto_s.Contact.Requests;
using LeMail.Application.Dto_s.Contact.Responses;
using LeMail.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeMail.WebApi.Controllers;
/// <summary>
/// Contact api controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    /// <summary>
    /// Contact service
    /// </summary>
    private readonly IContactService _contactService;
    

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
    /// <summary>
    /// Create contact query
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost] 
    public async Task<IActionResult> CreateContact(CreateContactRequest request, CancellationToken cancellationToken)
    {
        var response = await _contactService.CreateAsync(request, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// get Contact by id query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")] 
    public async Task<IActionResult> GetContactById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _contactService.GetContactByIdAsync(id, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }
    /// <summary>
    /// Update contact by id query
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactRequest request, CancellationToken cancellationToken)
    {

        var response = await _contactService.UpdateContactAsync(request, cancellationToken);
        if (response == null)
            return NotFound();
        return Ok(response);
    }
    /// <summary>
    /// Delete contact by id query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]//done
    public async Task<IActionResult> DeleteContact(Guid id, CancellationToken cancellationToken)
    {
        var result = await _contactService.DeleteContactByIdAsync(id, cancellationToken);
        
        if (!result)
            return NotFound();
        return NoContent();
    }

    /// <summary>
    /// Get all contacts query
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllContacts(CancellationToken cancellationToken)
    {
        var response = await _contactService.GetAllContactsAsync(cancellationToken);
        return Ok(response);
    }
    /// <summary>
    /// Get all contacts by User id query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("AllBy{id}")]
    public async Task<IActionResult> GetAllContactsByUserId(Guid id, CancellationToken cancellationToken)
    {
        var response = await _contactService.GetAllContactsByUserId(id, cancellationToken);
        return Ok(response);
    }
}