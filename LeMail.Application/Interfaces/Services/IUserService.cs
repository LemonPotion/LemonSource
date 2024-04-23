using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Dto_s.User.Responses;
using LeMail.Application.Interfaces.Repository;

namespace LeMail.Application.Interfaces.Services;

public interface IUserService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<GetUserResponse> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<CreateUserResponse>> GetAllUsersAsync(CancellationToken cancellationToken);
}
