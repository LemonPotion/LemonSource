using AutoMapper;
using LeMail.Application.Dto_s.User;
using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Dto_s.User.Responses;
using LeMail.Domain.Entities;
using LeMail.Domain.ValueObjects;

namespace LeMail.Application.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // CreateMap для маппинга Create User Request класса
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Salt, opt => opt.MapFrom(src => src.Salt))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

            // CreateMap для маппинга Delete User Request класса
            CreateMap<DeleteUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // CreateMap для маппинга Get User Request класса
            CreateMap<GetUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // CreateMap для маппинга Update User Request класса
            CreateMap<UpdateUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Salt, opt => opt.MapFrom(src => src.Salt))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

            // CreateMap для маппинга User класса на Create User Response класс
            CreateMap<User, CreateUserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Salt, opt => opt.MapFrom(src => src.Salt))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

            // CreateMap для маппинга User класса на Delete User Response класс
            CreateMap<User, DeleteUserResponse>()
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => true));

            // CreateMap для маппинга User класса на Get User Response класс
            CreateMap<User, GetUserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Salt, opt => opt.MapFrom(src => src.Salt))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            
            CreateMap<FullNameDto, FullName>();

            CreateMap<FullName, FullNameDto>();

            // CreateMap для маппинга User класса на Update User Response класс
            CreateMap<User, UpdateUserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Salt, opt => opt.MapFrom(src => src.Salt))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
