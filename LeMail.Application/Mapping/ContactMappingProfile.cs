using AutoMapper;
using LeMail.Application.Dto_s.Contact.Requests;
using LeMail.Application.Dto_s.Contact.Responses;
using LeMail.Domain.Entities;

namespace LeMail.Application.Mapping;

//TODO: доделать маппинг
public class ContactMappingProfile : Profile
{
    public ContactMappingProfile()
    {
        // CreateMap для маппинга Create Contact Request класса
        CreateMap<CreateContactRequest, Contact>();

        // CreateMap для маппинга Delete Contact Request класса
        CreateMap<DeleteContactRequest, Contact>();

        // CreateMap для маппинга Get Contact Request класса
        CreateMap<GetContactRequest, Contact>();

        // CreateMap для маппинга Update Contact Request класса
        CreateMap<UpdateContactRequest, Contact>();

        // CreateMap для маппинга Contact класса на Create Contact Response класс
        CreateMap<Contact, CreateContactResponse>();

        // CreateMap для маппинга Contact класса на Delete Contact Response класс
        CreateMap<Contact, DeleteContactResponse>();

        // CreateMap для маппинга Contact класса на Get Contact Response класс
        CreateMap<Contact, GetContactResponse>();

        // CreateMap для маппинга Contact класса на Update Contact Response класс
        CreateMap<Contact, UpdateContactResponse>();
    }
}