using LeMail.Application.Dto_s.Message.Requests;
using LeMail.Application.Dto_s.Message.Responses;
using LeMail.Domain.Entities;

namespace LeMail.Application.Interfaces.Services;

public interface IEmailService
{
    Task<bool> SendEmailAsync(CreateMessageRequest message, CancellationToken cancellationToken);
}