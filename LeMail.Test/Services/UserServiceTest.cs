using System.Runtime.CompilerServices;
using AutoMapper;
using LeMail.Application.Dto_s.User;
using LeMail.Application.Dto_s.User.Requests;
using LeMail.Application.Mapping;
using LeMail.Application.Services;
using LeMail.Domain.Validations.Primitives;
using LeMail.Persistence.Repositories;

namespace LeMail.Test.Services;

public class UserServiceTest
{
    private readonly UserService _userService;
    private readonly DbContextTest _dbContextTest;
    private Guid _userId;
    private string _email;
    private string _password;
    
    public UserServiceTest()
    {
        _dbContextTest = new DbContextTest();
        
        var userRepository = new UserRepository(_dbContextTest.DatabaseContext);
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new UserMappingProfile());
        });
        var mapper = mapperConfiguration.CreateMapper();
        
        _userService = new UserService(userRepository,mapper);
    }

    public async Task<Guid> RunTest()
    {
        await Create();
        await GetById();
        await GetList();
        await Update();
        return _userId;
    }

    public async Task DeleteOnExit(Guid userId)
    {
        _userId = userId;
        await Delete();
    }
    private async Task Create()
    {
        try
        {
            Console.WriteLine("Тестирование Create");
            var request = new CreateUserRequest
            {
                Role = Role.Admin, // Пример значения для свойства Role
                Email = "example@example.com",
                Password = "password123",
                FullName = new FullNameDto
                {
                    FirstName = "John",
                    LastName = "Doe",
                    MiddleName = "Karlov"
                }
            };
            var response = await _userService.CreateUserAsync(request, CancellationToken.None);
            _userId = response.Id;
            _email = response.Email;
            _password = response.Password;
            Console.WriteLine(response is not null ? "User создан" : "Ошибка при создании");
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
            var response = await _userService.GetUserByIdAsync(_userId, CancellationToken.None);
        
            // Обработка результата запроса
            Console.WriteLine(response is not null ? "User получен" : "Ошибка при получении по идентификатору");
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
            var response = await _userService.GetAllUsersAsync(CancellationToken.None);
            Console.WriteLine(response is not null ? "Список получен" : "Список пуст");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private async Task Login()
    {
        try
        {
            Console.WriteLine("Тестирование Login");
            
            var response = await _userService.LoginAsync(_email, _password, CancellationToken.None);
            
            Console.WriteLine(response is not null ? "Авторизация прошла успешно" : "Ошибка при авторизации");
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

            var response = await _userService.DeleteUserByIdAsync(_userId, CancellationToken.None);
            
            Console.WriteLine(response ? "Пользователь удален успешно." : "Ошибка при удалении пользователя.");
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
        
            // Создание запроса UpdateUserRequest с обновленными данными
            var request = new UpdateUserRequest
            {
                Id = _userId, // Идентификатор пользователя для обновления
                Role = Role.Admin, // Новая роль пользователя
                Email = "updated@example.com", // Новый email пользователя
                Password = "newpassword123", // Новый пароль пользователя
                FullName = new FullNameDto
                {
                    FirstName = "UpdatedFirstName",
                    LastName = "UpdatedLastName",
                    MiddleName = "UpdatedMiddleName"
                }
            };

            // Вызов метода UpdateUserAsync сервиса UserService
            var response = await _userService.UpdateUserAsync(request, CancellationToken.None);
        
            // Обработка результата запроса
            Console.WriteLine(response is not null ? "User обновлен" : "Ошибка при обновлении пользователя");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}