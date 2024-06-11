using AutoMapper;
using LeMail.Application.Dto_s.Attachment;
using LeMail.Application.Dto_s.Attachment.Requests;
using LeMail.Application.Dto_s.Attachment.Responses;
using LeMail.Application.Mapping.Converters;
using LeMail.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace LeMail.Application.Mapping
{
    public class AttachmentMappingProfile : Profile
    {
        public AttachmentMappingProfile()
        {
            CreateMap<IFormFile, CreateAttachmentRequest>() .ConvertUsing<FormFileToCreateAttachmentRequestConverter>();
            
            CreateMap<CreateAttachmentRequest, Attachment>()
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src.FileType));

            CreateMap<UpdateAttachmentRequest, Attachment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src.FileType));

            CreateMap<Attachment, CreateAttachmentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src.FileType));

            CreateMap<Attachment, UpdateAttachmentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src.FileType));

            CreateMap<Attachment, GetAttachmentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(src => src.FileType));
        }
    }
}
