using AutoMapper;
using LeMail.Application.Dto_s.Issue.Requests;
using LeMail.Application.Dto_s.Issue.Responses;
using LeMail.Domain.Entities;

namespace LeMail.Application.Mapping;

public class IssueMappingProfile : Profile
{
    public IssueMappingProfile()
    {
        CreateMap<CreateIssueRequest, Issue>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))

            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
          
        CreateMap<DeleteIssueRequest, Issue>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
        CreateMap<GetIssueRequest, Issue>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
        CreateMap<UpdateIssueRequest, Issue>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

           
        CreateMap<Issue, CreateIssueResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

          
        CreateMap<Issue, DeleteIssueResponse>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => true));

            
        CreateMap<Issue, GetIssueResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        CreateMap<Issue, UpdateIssueResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
    }
}