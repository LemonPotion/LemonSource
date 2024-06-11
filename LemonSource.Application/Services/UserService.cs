using AutoMapper;
using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;
using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Dto_s.User.Responses;
using LeMail.Application.Interfaces.Services;
using LeMail.Domain.Validations;
using LeMail.Domain.Validations.Validators.Entities;

namespace LeMail.Application.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request);
            
            var validator = new UserValidator(nameof(User));
            validator.ValidateWithExceptions(userEntity);
            
            var createdUser = await _userRepository.CreateAsync(userEntity, cancellationToken);
            return _mapper.Map<CreateUserResponse>(createdUser);
        }

        public async Task<GetUserResponse> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<GetUserResponse>(userEntity);
        }

        public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request, user);
            
            var updatedUser = await _userRepository.UpdateAsync(user, cancellationToken);
            
            return _mapper.Map<UpdateUserResponse>(updatedUser);
        }

        public async Task<bool> DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteByIdAsync(id, cancellationToken);
        }

        public async Task<List<GetUserResponse>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var userEntities = await _userRepository.GetAllListAsync(cancellationToken);
            return _mapper.Map<List<GetUserResponse>>(userEntities);
        }

        public async Task<GetUserResponse> LoginAsync(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userRepository.LoginAsync(email, password, cancellationToken);
            return _mapper.Map<GetUserResponse>(user);
        }
    }



}
