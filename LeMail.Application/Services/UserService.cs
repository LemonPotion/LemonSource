using AutoMapper;
using LeMail.Application.Interfaces.Repository;
using LeMail.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeMail.Application.Dto_s.User;
using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Dto_s.User.Responses;
using LeMail.Application.Interfaces.Services;

    //TODO: сделать остальные сервисы
    //TODO: сделать рабочий маппинг
namespace LeMail.Application.Services
{
    public class UserService
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
            var user = _mapper.Map<User>(request);
            var createdUser = await _userRepository.CreateAsync(user, cancellationToken);
            var response = _mapper.Map<CreateUserResponse>(createdUser);
            return response;
        }

        public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest deleteUserRequest, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(deleteUserRequest);
            var Isdeleted = _userRepository.GetByIdAsync(user.Id, cancellationToken);
            var response = _mapper.Map<DeleteUserResponse>(Isdeleted);
            return response;
        }

        public async Task<GetUserResponse> GetUserAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(id, cancellationToken);
            var response = _mapper.Map<GetUserResponse>(user);
            return response;
        }
        
        public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var getUserByIdResponse = await GetUserAsync(request.Id, cancellationToken);
            var user = _mapper.Map<User>(getUserByIdResponse);
            user.Update(request.Email, request.FullName.LastName, request.FullName.FirstName, request.FullName.MiddleName);
            await _userRepository.UpdateAsync(user,cancellationToken);
            var response = _mapper.Map<UpdateUserResponse>(user);
            return response;
        }
    }
}
