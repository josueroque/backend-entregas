using System.Reflection;
using System.Text;
using BookManager.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookManager.IntegrationTests.TestSupport;
public abstract class IntegrationTest
    : IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly string _uniqueDatabaseName;
    protected HttpClient HttpClient { get; }

    protected string Token { get; set; } = string.Empty;
    protected IntegrationTest()
    {
        var server =
            new TestServer(
                new WebHostBuilder()
                    .UseStartup<Startup>()
                    .UseEnvironment("Test")
                    .UseCommonConfiguration()
                    .ConfigureTestServices(ConfigureTestServices));

        HttpClient = server.CreateClient();

        // Strategy to use a unique DB schema per test execution
        _serviceProvider = server.Services;
        _uniqueDatabaseName = $"Test-{Guid.NewGuid()}";
        // Apply Migrations
        using var dbContext = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();
        dbContext.Database.Migrate();
    }

    protected virtual void ConfigureTestServices(IServiceCollection services)
    {

        RemoveDependencyInjectionRegisteredService<DbContextOptions<BookDbContext>>(services);

        services.AddDbContext<BookDbContext>(
            (sp, options) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();

                var storedUsername = configuration.GetValue<string>("BasicAuthentication:Username");
                var storedPassword = configuration.GetValue<string>("BasicAuthentication:Password");

                Token = Base64Encode($"{storedUsername}:{storedPassword}");

                var testConnectionString = configuration.GetValue<string>("ConnectionStrings:BooksDatabase");
                var parts = testConnectionString!.Split(";");
                var uniqueDbTestConnectionStringBuilder = new StringBuilder();
                foreach (var part in parts)
                {
                    var isDatabasePart = part.StartsWith("Database=");
                    uniqueDbTestConnectionStringBuilder.Append(isDatabasePart
                        ? $"Database={_uniqueDatabaseName};"
                        : $"{part};");
                }

                var uniqueDbTestConnectionString = uniqueDbTestConnectionStringBuilder.ToString().TrimEnd(';');
                options.UseSqlServer(uniqueDbTestConnectionString);
            });
    }
    private static string Base64Encode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }
    private void RemoveDependencyInjectionRegisteredService<TService>(IServiceCollection services)
    {
        var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(TService));
        if (serviceDescriptor != null)
        {
            services.Remove(serviceDescriptor);
        }
    }

    public void Dispose()
    {
        using var dbContext = _serviceProvider.GetService<BookDbContext>();
        dbContext?.Database.EnsureDeleted();
    }
}

internal static class WebHostBuilderExtensions
{
    internal static IWebHostBuilder UseCommonConfiguration(this IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            var env = hostingContext.HostingEnvironment;

            config
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                config.AddUserSecrets(appAssembly, optional: true);
            }
        });

        return builder;
    }
}
