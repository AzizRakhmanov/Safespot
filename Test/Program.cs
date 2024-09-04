using Safespot.Service.Services.EmailService;
using Test;

namespace QuartzSampleApp
{
    public class Program
    {
        private static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

            builder.Services
                    .AddGraphQLServer()
                    .AddQueryType<Test.Query>();

            builder.Build();
            var app = builder.Build();

            app.MapGraphQL();
        }
    }
}