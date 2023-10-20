using Microsoft.AspNetCore.HttpOverrides;
using Service.Contracts;
using Services.DataShaping;
using Services.LoggerService;
using Shared.DataTransferObjects;
using Web.Extentions;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.ConfigureNpgsqlContext(builder.Configuration);
            builder.Services.ConfigureRepositoryManager();
            builder.Services.AddControllers(config =>
            {
                //config.Filters.Add(new GlobalFilterExample());
            });
            //builder.Services.AddScoped<ActionFilterExample>();
            //builder.Services.AddScoped<ControllerFilterExample>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureCors(); 
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.AddScoped<IDataShaper<GraphicCardDto>, DataShaper<GraphicCardDto>>();




            var app = builder.Build();

            var logger = app.Services.GetRequiredService<ILoggerManager>(); 
            app.ConfigureExceptionHandler(logger); 
            if (app.Environment.IsProduction()) 
                app.UseHsts(); 
            app.UseHttpsRedirection();
            app.UseStaticFiles(); 
            app.UseForwardedHeaders(new ForwardedHeadersOptions 
            { 
                ForwardedHeaders = ForwardedHeaders.All 
            }); 
            app.UseCors("CorsPolicy"); 
            app.UseAuthorization(); 
            app.MapControllers(); 
            
            //LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.Run();
        }
    }

}