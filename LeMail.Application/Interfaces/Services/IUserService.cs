using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Dto_s.User.Responses;

namespace LeMail.Application.Interfaces.Services;
public interface IUserService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<GetUserResponse> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<GetUserResponse>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<GetUserResponse> LoginAsync(string email, string password, CancellationToken cancellationToken);
}
