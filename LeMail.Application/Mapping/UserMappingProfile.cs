using AutoMapper;
using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Dto_s.User.Responses;
using LeMail.Domain.Entities;
using LeMail.Domain.ValueObjects;

namespace LeMail.Application.Mapping;

public class UserMappingProfile : Profile
{
    //TODO: сделать рабочий маппинг
    public UserMappingProfile()
    {
        // CreateMap для маппинга Create User Request класса
        CreateMap<CreateUserRequest, User>();

        // CreateMap для маппинга Delete User Request класса
        CreateMap<DeleteUserRequest, User>();

        // CreateMap для маппинга Get User Request класса
        CreateMap<GetUserRequest, User>();

        // CreateMap для маппинга Update User Request класса
        CreateMap<UpdateUserRequest, User>();

        // CreateMap для маппинга User класса на Create User Response класс
        CreateMap<User, CreateUserResponse>();

        // CreateMap для маппинга User класса на Delete User Response класс
        CreateMap<User, DeleteUserResponse>();

        // CreateMap для маппинга User класса на Get User Response класс
        CreateMap<User, GetUserResponse>();

        // CreateMap для маппинга User класса на Update User Response класс
        CreateMap<User, UpdateUserResponse>();
    }
}