using System.Net;
using System.Net.Mail;
using AutoMapper;
using LeMail.Application.Dto_s.Message.Requests;
using LeMail.Application.Dto_s.Message.Responses;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace LeMail.Application.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public EmailService(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<bool> SendEmailAsync(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var message = _mapper.Map<Message>(request);
        
        using var smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpServer"]);
        smtpClient.Port =int.Parse(_configuration["EmailSettings:Port"]);
        var fromEmail = _configuration["EmailSettings:From"];
        var password = _configuration["EmailSettings:Password"];
        smtpClient.EnableSsl =  bool.Parse(_configuration["EmailSettings:EnableSsl"]);
        
        smtpClient.Credentials = new NetworkCredential(fromEmail, password);
        
        var mailMessage = new MailMessage
        {
            From = new MailAddress("vladred2016@gmail.com"),
            Subject = message.Subject,
            Body = message.Body,
            To = { message.To }
        };
        try
        {

            await smtpClient.SendMailAsync(mailMessage, cancellationToken);
            return true;
        }
        catch(Exception exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }
    }
}