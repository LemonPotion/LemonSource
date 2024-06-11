using AutoMapper;
using LeMail.Application.Dto_s.Article.Requests;
using LeMail.Application.Dto_s.Article.Responses;
using LeMail.Domain.Entities;

namespace LeMail.Application.Mapping;

public class ArticleMappingProfile : Profile
{
    public ArticleMappingProfile()
    {
        CreateMap<CreateArticleRequest, Article>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));
          
        CreateMap<DeleteArticleRequest, Article>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
        CreateMap<GetArticleRequest, Article>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

         
        CreateMap<UpdateArticleRequest, Article>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));

           
        CreateMap<Article, CreateArticleResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));

          
        CreateMap<Article, DeleteArticleResponse>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => true));

            
        CreateMap<Article, GetArticleResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));
        
        CreateMap<Article, UpdateArticleResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src.Link))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre));
    }
}