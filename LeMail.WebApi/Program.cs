
using LeMail.Application.Interfaces.Repository;
using LeMail.Application.Interfaces.Services;
using LeMail.Application.Services;
using LeMail.Persistence;
using LeMail.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeMail.WebApi
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Регистрация сервисов и репозиториев
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();

            builder.Services.AddScoped<IReviewerService, ReviewerService>();
            builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();
            
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            
            builder.Services.AddScoped<IIssueService, IssueService>();
            builder.Services.AddScoped<IIssueRepository, IssueRepository>();
            
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            
            builder.Services.AddScoped<IArticleService, ArticleService>();
            builder.Services.AddScoped<IArticleRepository, ArticleRepository>();

            builder.Services.AddScoped<IFileService, FileService>();
            
            // Настройка AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
