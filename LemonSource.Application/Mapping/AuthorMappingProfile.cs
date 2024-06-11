using AutoMapper;
using LeMail.Application.Dto_s.Author.Requests;
using LeMail.Application.Dto_s.Author.Responses;
using LeMail.Application.Dto_s.User;
using LeMail.Domain.Entities;
using LeMail.Domain.ValueObjects;

namespace LeMail.Application.Mapping;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<CreateAuthorRequest, Author>()
            .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
            .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
          
        CreateMap<DeleteAuthorRequest, Author>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
        CreateMap<GetAuthorRequest, Author>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
        CreateMap<UpdateAuthorRequest, Author>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
            .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

           
        CreateMap<Author, CreateAuthorResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
            .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

          
        CreateMap<Author, DeleteAuthorResponse>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => true));

            
        CreateMap<Author, GetAuthorResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
            .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<FullNameDto, FullName>();

        CreateMap<FullName, FullNameDto>();
        
        CreateMap<Author, UpdateAuthorResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
            .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
    }
}