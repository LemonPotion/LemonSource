using AutoMapper;
using LeMail.Application.Dto_s.Message;
using LeMail.Application.Dto_s.Message.Requests;
using LeMail.Application.Dto_s.Message.Responses;
using LeMail.Domain.Entities;

namespace LeMail.Application.Mapping
{
    public class MessageMappingProfile : Profile
    {
        public MessageMappingProfile()
        {
            // CreateMap для маппинга Create Message Request класса
            CreateMap<CreateMessageRequest, Message>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Не устанавливать Id, оставить его для генерации
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.DateSent, opt => opt.MapFrom(src => src.DateSent))
                .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.To));

            // CreateMap для маппинга Delete Message Request класса
            CreateMap<DeleteMessageRequest, Message>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // CreateMap для маппинга Get Message Request класса
            CreateMap<GetMessageRequest, Message>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            // CreateMap для маппинга Update Message Request класса
            CreateMap<UpdateMessageRequest, Message>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.DateSent, opt => opt.MapFrom(src => src.DateSent));

            // CreateMap для маппинга Message класса на Create Message Response класс
            CreateMap<Message, CreateMessageResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.DateSent, opt => opt.MapFrom(src => src.DateSent));

            // CreateMap для маппинга Message класса на Delete Message Response класс
            CreateMap<Message, DeleteMessageResponse>()
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true)); // Предполагая, что удаление всегда успешно

            // CreateMap для маппинга Message класса на Get Message Response класс
            CreateMap<Message, GetMessageResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.DateSent, opt => opt.MapFrom(src => src.DateSent));

            // CreateMap для маппинга Message класса на Update Message Response класс
            CreateMap<Message, UpdateMessageResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.DateSent, opt => opt.MapFrom(src => src.DateSent));
            
            CreateMap<ExtendedUserDto, BaseMessageDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id)); // Маппинг Id на UserId
            // CreateMap для маппинга ExtendedUserDto на User
            CreateMap<User, ExtendedUserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
