using LeMail.Application.Dto_s.User;

namespace LeMail.Application.Dto_s.Reviewer.Responses;

public class CreateReviewerResponse : BaseReviewerDto
{
    public Guid Id { get; init; }
}