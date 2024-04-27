using AutoMapper;
using LeMail.Application.Dto_s.Contact.Requests;
using LeMail.Application.Dto_s.Contact.Responses;
using LeMail.Domain.Entities;

namespace LeMail.Application.Mapping;

public class ContactMappingProfile : Profile
{
    public ContactMappingProfile()
    {
        // CreateMap для маппинга Create Contact Request класса
        CreateMap<CreateContactRequest, Contact>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
            .ForMember(dest => dest.ContactMail, opt => opt.MapFrom(src => src.ContactMail));
            

        // CreateMap для маппинга Delete Contact Request класса
        CreateMap<DeleteContactRequest, Contact>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src=> src.Id));
        

        // CreateMap для маппинга Get Contact Request класса
        CreateMap<GetContactRequest, Contact>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src=> src.Id));

        // CreateMap для маппинга Update Contact Request класса
        CreateMap<UpdateContactRequest, Contact>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src=> src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
            .ForMember(dest => dest.ContactMail, opt => opt.MapFrom(src => src.ContactMail));

        // CreateMap для маппинга Contact класса на Create Contact Response класс
        CreateMap<Contact, CreateContactResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src=> src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
            .ForMember(dest => dest.ContactMail, opt => opt.MapFrom(src => src.ContactMail));

        // CreateMap для маппинга Contact класса на Delete Contact Response класс
        CreateMap<Contact, DeleteContactResponse>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));

        // CreateMap для маппинга Contact класса на Get Contact Response класс
        CreateMap<Contact, GetContactResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src=> src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
            .ForMember(dest => dest.ContactMail, opt => opt.MapFrom(src => src.ContactMail));
        

        // CreateMap для маппинга Contact класса на Update Contact Response класс
        CreateMap<Contact, UpdateContactResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src=> src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
            .ForMember(dest => dest.ContactMail, opt => opt.MapFrom(src => src.ContactMail));
    }
}