using AutoMapper;
using LeMail.Application.Dto_s.Review.Requests;
using LeMail.Application.Dto_s.Review.Responses;
using LeMail.Application.Dto_s.User;
using LeMail.Domain.Entities;
using LeMail.Domain.ValueObjects;

namespace LeMail.Application.Mapping;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<CreateReviewRequest, Review>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
          
        CreateMap<DeleteReviewRequest, Review>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
        CreateMap<GetReviewRequest, Review>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
        CreateMap<UpdateReviewRequest, Review>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

           
        CreateMap<Review, CreateReviewResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

          
        CreateMap<Review, DeleteReviewResponse>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => true));

            
        CreateMap<Review, GetReviewResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        
        CreateMap<Review, UpdateReviewResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
    }
}