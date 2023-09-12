using BookManager.Application;
using BookManager.Persistance;
using Microsoft.EntityFrameworkCore;
using BookManager.Extensions;

namespace BookManager;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var booksConnectionString =
            _configuration.GetValue<string>("ConnectionStrings:BooksDatabase");

        services
            .AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlServer(booksConnectionString);
            })
            .AddTransient<AuthorCommandService>()
            .AddTransient<BookCommandService>()
            .AddTransient<BookQueryService>()
            .AddScoped<IBookDbContext, BookDbContext>()
            .AddOpenApi()
            .AddControllers();
    }


    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseOpenApi();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}