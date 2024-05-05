using LeMail.Domain.Entities;
using LeMail.Domain.Validations.Primitives;
using LeMail.Domain.ValueObjects;
using LeMail.Persistence;
using LeMail.Test.Services;
using Microsoft.Extensions.Configuration;

namespace LeMail.Test;

class Program
{
    private static void Main(string[] args)
    {
        var userId = Guid.Empty;
        var messageId = Guid.Empty;
        IConfiguration configuration = null;
        while (true)
        {
            Console.WriteLine("Что протестировать?");
            Console.WriteLine("0.Контекст базы данных");
            Console.WriteLine("1.UserService");
            Console.WriteLine("2.MessageService");
            Console.WriteLine("3.ContactService");
            Console.WriteLine("4.AttachmentService");
            Console.WriteLine("5.Выход");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    var success =Initialize(new DbContextTest().DatabaseContext);
                
                    Console.WriteLine(success ? "Тест прошел успешно" : "Произошла ошибка");
                
                    break;
                case "1":
                    var userIdTest = new UserServiceTest().RunTest().GetAwaiter().GetResult();
                    userId = userIdTest;
                
                    break;
                case "2":
                    if (userId != Guid.Empty)
                    { 
                        var currentDirectory = Directory.GetCurrentDirectory();
                        var indexToRemove = currentDirectory.IndexOf(@"\LeMail.Test\bin\Debug\net8.0");
                        
                        var projectDirectory = currentDirectory.Remove(indexToRemove);

                        var configFilePath = @$"{projectDirectory}\LeMail.WebApi\appsettings.json";
                        
                        Console.WriteLine(configFilePath);
                        
                        IConfiguration configurationTest = new ConfigurationBuilder()
                            .AddJsonFile(configFilePath, optional: false, reloadOnChange: false)
                            .Build();
                        var messageIdTest = new MessageServiceTest(configurationTest,userId).RunTest().GetAwaiter().GetResult();
                        messageId = messageIdTest;
                        configuration = configurationTest;

                    }
                    else
                    {
                        Console.WriteLine("userId is empty");
                    }
                    break;
                case "3":
                    if (userId != Guid.Empty)
                    {
                        new ContactServiceTest(userId).RunTest().GetAwaiter().GetResult();
                    }
                    else
                    {
                        Console.WriteLine("userId is empty");
                    }
                    break;
                case "4":
                    if (userId != Guid.Empty)
                    {
                        new AttachmentServiceTest(userId, messageId).RunTest().GetAwaiter().GetResult();
                    }
                    else
                    {
                        Console.WriteLine("userId is empty");
                    }
                    break;
                case "5":
                    new MessageServiceTest(configuration, userId).DeleteOnExit(messageId).GetAwaiter().GetResult();
                    new UserServiceTest().DeleteOnExit(userId).GetAwaiter().GetResult();
                    userId = Guid.Empty;
                    messageId = Guid.Empty;
                    break;
            
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }  
        }
    }

    private static bool Initialize(DatabaseContext context)
    {
        context.Database.EnsureCreated();
        var user = new User
        {
            Role = Role.Admin,
            Email = "admin@example.com",
            Password = "password123",
            FullName = new FullName("John", "Doe", "Karlov")
        };

        // Добавление пользователя в контекст и сохранение его
        context.Users.Add(user);
        context.SaveChanges();

        // Теперь, когда пользователь сохранен, вы можете использовать его Id для контакта
        var contact = new Contact
        {
            ContactName = "John",
            ContactMail = "john@example.com",
            Description = "Example contact",
            UserId = user.Id // Устанавливаем Id пользователя
        };

        // Добавление контакта в контекст
        context.Contacts.Add(contact);

        // Добавление сообщения
        var message = new Message
        {
            User = user,
            Subject = "Test subject",
            Body = "Test body",
            To = "recipient@example.com",
            DateSent = DateTime.Now,
            Attachments = new List<Attachment>()
        };

        // Добавление сообщения в контекст
        context.Messages.Add(message);

        // Добавление вложения
        var attachment = new Attachment
        {
            FileName = "example.txt",
            FilePath = "/path/to/file",
            FileType = "txt",
            Message = message
        };

        // Добавление вложения в контекст
        context.Attachments.Add(attachment);

        // Сохранение изменений в базе данных
        context.SaveChanges();
        Console.WriteLine("Данные добавлены");

        context.Attachments.Remove(attachment);
        context.Messages.Remove(message);
        context.Contacts.Remove(contact);
        context.Users.Remove(user);
        context.SaveChanges();
        Console.WriteLine("Данные удалены");
        return true;
    }
}