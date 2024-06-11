using LeMail.Application.Dto_s.User;

namespace LeMail.Application.Dto_s.Author;

public class BaseAuthorDto
{
    public string NickName { get; set; }
    public string? Degree { get; set; }
    public FullNameDto? FullName { get; set; }
}