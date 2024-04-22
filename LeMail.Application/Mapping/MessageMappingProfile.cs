using AutoMapper;
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
            CreateMap<CreateMessageRequest, Message>();

            // CreateMap для маппинга Delete Message Request класса
            CreateMap<DeleteMessageRequest, Message>();

            // CreateMap для маппинга Get Message Request класса
            CreateMap<GetMessageRequest, Message>();

            // CreateMap для маппинга Update Message Request класса
            CreateMap<UpdateMessageRequest, Message>();

            // CreateMap для маппинга Message класса на Create Message Response класс
            CreateMap<Message, CreateMessageResponse>();

            // CreateMap для маппинга Message класса на Delete Message Response класс
            CreateMap<Message, DeleteMessageResponse>();

            // CreateMap для маппинга Message класса на Get Message Response класс
            CreateMap<Message, GetMessageResponse>();

            // CreateMap для маппинга Message класса на Update Message Response класс
            CreateMap<Message, UpdateMessageResponse>();
        }
    }
}