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
    //TODO: разобраться почему не добавляет в бд
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
            var existingUser = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingUser == null)
            {
                // Handle the case where the user doesn't exist
                return null;
            }

            _mapper.Map(request, existingUser);
            var updatedUser = await _userRepository.UpdateAsync(existingUser, cancellationToken);
            return _mapper.Map<UpdateUserResponse>(updatedUser);
        }

        public async Task<bool> DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteByIdAsync(id, cancellationToken);
        }

        public async Task<List<CreateUserResponse>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var userEntities = await _userRepository.GetAllListAsync(cancellationToken);
            return _mapper.Map<List<CreateUserResponse>>(userEntities);
        }
    }



}
