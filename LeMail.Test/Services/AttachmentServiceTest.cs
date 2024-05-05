using AutoMapper;
using LeMail.Application.Dto_s.Attachment.Requests;
using LeMail.Application.Mapping;
using LeMail.Application.Services;
using LeMail.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace LeMail.Test.Services;

public class AttachmentServiceTest
{
    private readonly AttachmentService _attachmentService;
    private readonly DbContextTest _dbContextTest;
    private Guid _userId;
    private Guid _messageId;
    private Guid _attachmentId;

    public AttachmentServiceTest(Guid userId, Guid messageId)
    {
        _userId = userId;
        _messageId = messageId;
        _dbContextTest = new DbContextTest();
        
        var attachmentRepository = new AttachmentRepository(_dbContextTest.DatabaseContext);
        
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AttachmentMappingProfile());
        });
        var fileService = new FileService();
        var mapper = mapperConfiguration.CreateMapper();
        _attachmentService = new AttachmentService(attachmentRepository,mapper, fileService);
    }
    public async Task RunTest()
    {
        await Create(); 
        await GetById(); 
        await GetList();
        await Delete();
    }

    private async Task Create()
    {
        try
        {
            Console.WriteLine("Тестирование Create");
            
            var currentDirectory = Directory.GetCurrentDirectory();
            var indexToRemove = currentDirectory.IndexOf(@"\LeMail.Test\bin\Debug\net8.0");
                        
            var projectDirectory = currentDirectory.Remove(indexToRemove);
            var path = @$"{projectDirectory}\LeMail.WebApi\testAttachment.txt";
            Console.WriteLine(path);
            await using var stream = new FileStream(path, FileMode.Open);
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };
            
            var response = await _attachmentService.CreateAttachmentAsync(_messageId,file,CancellationToken.None);
            _attachmentId= response.Id;
            
            Console.WriteLine(response is not null ? "Attachment создан" : "Ошибка при создании");
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
            
            var response = await _attachmentService.GetAttachmentByIdAsync(_attachmentId, CancellationToken.None);
        

            Console.WriteLine(response is not null ? "Attachment получен" : "Ошибка при получении по идентификатору");
                
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
            var response = await _attachmentService.GetAllAttachmentsAsync(CancellationToken.None);
            Console.WriteLine(response is not null ? "Список получен" : "Список пуст");
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
            
            var response = await _attachmentService.DeleteAttachmentByIdAsync(_attachmentId, CancellationToken.None);
            
            Console.WriteLine(response ? "Attachment удален успешно." : "Ошибка при удалении .");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}