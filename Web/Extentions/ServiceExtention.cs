
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Service.Contracts;
using Services;
using Services.LoggerService;

namespace Web.Extentions
{
    public static class ServiceExtention
    {


        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
        //Настройка политики Cors. Разрешаем запросы от любого домена.
        //Разрешаем все методы HTTP.
        //Разрешаем все заголовки HTTP.
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"));
    });
        //Настройки интеграции в IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        //Подключение БД
        public static void ConfigureNpgsqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseNpgsql(configuration.GetConnectionString("HardwareGeniusDataBase")));

        //Регистрация менеджера работы с репозиторием

        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
        //Регистрация менеджера сервисов
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

      
    }
}
