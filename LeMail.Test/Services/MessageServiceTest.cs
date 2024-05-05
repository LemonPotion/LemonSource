using AutoMapper;
using LeMail.Application.Dto_s.Message.Requests;
using LeMail.Application.Mapping;
using LeMail.Application.Services;
using LeMail.Persistence.Repositories;
using Microsoft.Extensions.Configuration;

namespace LeMail.Test.Services;

    public class MessageServiceTest
    {
        private readonly IConfiguration _configuration;
        private readonly MessageService _messageService;
        private readonly DbContextTest _dbContextTest;
        private Guid _userId;
        private Guid _messageId;

        public MessageServiceTest(IConfiguration configuration, Guid userId)
        {
            _userId = userId;
            _configuration = configuration;
            _dbContextTest = new DbContextTest();
            var messageRepository = new MessageRepository(_dbContextTest.DatabaseContext);
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MessageMappingProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();
            var emailService = new EmailService(_configuration,mapper);
            _messageService = new MessageService(messageRepository,mapper, emailService);
        }

        public async Task<Guid> RunTest()
        {
            await Create();
            await GetById();
            await GetList();
            await GetAllByUserId();
            await Update();
            return _messageId;
        }

        public async Task DeleteOnExit(Guid messageId)
        {
            _messageId = messageId;
            await Delete();
        }

        private async Task Create()
        {
            try
            {
                Console.WriteLine("Тестирование Create");
                
                var request = new CreateMessageRequest
                {
                    UserId = _userId,
                    Subject = "Test Subject",
                    Body = "Test Body",
                    To = "vladred2016@gmail.com"
                };
                
                var response = await _messageService.CreateMessageAsync(request, CancellationToken.None);
                _messageId = response.Id;
                Console.WriteLine(response is not null ? "Message создан" : "Ошибка при создании");
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
                var response = await _messageService.GetMessageByIdAsync(_messageId, CancellationToken.None);
        
                // Обработка результата запроса
                Console.WriteLine(response is not null ? "Message получен" : "Ошибка при получении по идентификатору");
                
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
                var response = await _messageService.GetAllMessagesAsync(CancellationToken.None);
                Console.WriteLine(response is not null ? "Список получен" : "Список пуст");
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
                var request = new UpdateMessageRequest
                {
                    Id = _messageId, // Замените messageId на фактический идентификатор сообщения, которое вы хотите обновить
                    Subject = "Updated Subject", // Новая тема сообщения
                    Body = "Updated Body", // Новое тело сообщения
                    To = "newrecipient@example.com",
                    UserId = _userId
                };
                
                var response = await _messageService.UpdateMessageAsync(request, CancellationToken.None);
                Console.WriteLine(response is not null ? "Message обновлен" : "Ошибка при обновлении");
                
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
                
                var response = await _messageService.GetAllListByUserIdAsync(_userId, CancellationToken.None);
                
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
                var response = await _messageService.DeleteMessageByIdAsync(_messageId, CancellationToken.None);
            
                Console.WriteLine(response ? "Message удален успешно." : "Ошибка при удалении .");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
