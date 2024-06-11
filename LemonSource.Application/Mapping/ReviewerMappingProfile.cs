using AutoMapper;
using LeMail.Application.Dto_s.Reviewer.Requests;
using LeMail.Application.Dto_s.Reviewer.Responses;
using LeMail.Application.Dto_s.User;
using LeMail.Domain.Entities;
using LeMail.Domain.ValueObjects;

namespace LeMail.Application.Mapping;

public class ReviewerMappingProfile : Profile
{
    public ReviewerMappingProfile()
    {
        CreateMap<CreateReviewerRequest, Reviewer>()
            .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree));
          
            CreateMap<DeleteReviewerRequest, Reviewer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
            CreateMap<GetReviewerRequest, Reviewer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
            CreateMap<UpdateReviewerRequest, Reviewer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

           
            CreateMap<Reviewer, CreateReviewerResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));

          
            CreateMap<Reviewer, DeleteReviewerResponse>()
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => true));

            
            CreateMap<Reviewer, GetReviewerResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
            
            CreateMap<FullNameDto, FullName>();

            CreateMap<FullName, FullNameDto>();

            
            CreateMap<Reviewer, UpdateReviewerResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));
    }
}