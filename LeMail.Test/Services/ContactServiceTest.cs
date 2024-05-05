using AutoMapper;
using LeMail.Application.Dto_s.Contact.Requests;
using LeMail.Application.Mapping;
using LeMail.Application.Services;
using LeMail.Persistence.Repositories;
using Microsoft.Extensions.Configuration;

namespace LeMail.Test.Services;

public class ContactServiceTest
{
    private readonly ContactService _contactService;
    private readonly DbContextTest _dbContextTest;
    private Guid _userId;
    private Guid _contactId;
    
    public ContactServiceTest(Guid userId)
    {
        _userId = userId;
        _dbContextTest = new DbContextTest();
        
        var contactRepository = new ContactRepository(_dbContextTest.DatabaseContext);
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ContactMappingProfile());
        });
        var mapper = mapperConfiguration.CreateMapper();
        _contactService = new ContactService(contactRepository,mapper);
    }
    public async Task RunTest()
    {
        await Create();
        await GetById();
        await GetList();
        await GetAllByUserId();
        await Update();
        await Delete();
    }
    private async Task Create()
    {
        try
        {
            Console.WriteLine("Тестирование Create");
                
            var request = new CreateContactRequest
            {
                ContactName = "Test Contact",
                ContactMail = "email@example.com",
                Description = "Test Description",
                UserId = _userId
            };
                
            var response = await _contactService.CreateAsync(request, CancellationToken.None);
            _contactId = response.Id;
            Console.WriteLine(response is not null ? "Contact создан" : "Ошибка при создании");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    private async Task Delete()
    {
        try
        {
            Console.WriteLine("Тестирование Delete");
            var response = await _contactService.DeleteContactByIdAsync(_contactId, CancellationToken.None);
            
            Console.WriteLine(response ? "Contact удален успешно." : "Ошибка при удалении .");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task Update()
    {
        try
        {
            Console.WriteLine("Тестирование Update");
            var request = new UpdateContactRequest
            {
                Id = _contactId,
                ContactName = "Test Contact",
                ContactMail = "email@example.com",
                Description = "Test Description",
                UserId = _userId
            };
                
            var response = await _contactService.UpdateContactAsync(request, CancellationToken.None);
            Console.WriteLine(response is not null ? "Contact обновлен" : "Ошибка при обновлении");
                
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task GetAllByUserId()
    {
        try
        {
            Console.WriteLine("Тестирование GetAllByUserId");
                
            var response = await _contactService.GetAllContactsByUserId(_userId, CancellationToken.None);
                
            Console.WriteLine(response is not null ? "Список получен" : "Список пуст");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task GetList()
    {
        try
        {
            Console.WriteLine("Тестирование GetList");
            var response = await _contactService.GetAllContactsAsync(CancellationToken.None);
            Console.WriteLine(response is not null ? "Список получен" : "Список пуст");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task GetById()
    {
        try
        {
            Console.WriteLine("Тестирование GetById");
            // Вызов метода GetUserAsync сервиса UserService
            var response = await _contactService.GetContactByIdAsync(_contactId, CancellationToken.None);
        
            // Обработка результата запроса
            Console.WriteLine(response is not null ? "Contact получен" : "Ошибка при получении по идентификатору");
                
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}