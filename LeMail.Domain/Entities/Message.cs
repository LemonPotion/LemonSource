using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators;

namespace LeMail.Domain.Entities;

public class Message: BaseEntity
{
    public User User { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime DateSent { get; set; }

    public Message(Guid id,User user,DateTime dateSent ,string subject, string body)
    {
        var idValidationResult = new IdValidator(nameof(id)).ValidateWithExceptions(id);
        Id = id;
        var userValidationResult = new UserValidator(nameof(user)).ValidateWithExceptions(user);
        User = user;
        var subjectValidationResult = new SubjectValidator(nameof(subject)).ValidateWithExceptions(subject);
        Subject = subject;
        var bodyValidationResult = new BodyValidator(nameof(body)).ValidateWithExceptions(body);
        Body = body;
        var dateSentValidationResult = new DateSentValidator(nameof(dateSent)).ValidateWithExceptions(dateSent);
        DateSent = dateSent;
    }
    
}