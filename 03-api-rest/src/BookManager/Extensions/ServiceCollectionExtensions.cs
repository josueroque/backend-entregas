using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BookManager.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenApi(this IServiceCollection services)
    {
        var mainAssemblyName = typeof(Startup).Assembly.GetName().Name;

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = mainAssemblyName,
                Version = "v1",
                Description = "BookManager Sample",
                Contact = new OpenApiContact
                {
                    Name = "Developer"
                }
            });

            c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                In = ParameterLocation.Header,
                Description = "Basic Authorization header using the Bearer scheme."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });

            c.DocumentFilter<LowerCaseDocumentFilter>();



        });


        return services;
    }
}


// ReSharper disable once ClassNeverInstantiated.Global
public class LowerCaseDocumentFilter
    : IDocumentFilter
{
    private static string LowercaseEverythingButParameters(string key) => string.Join('/', key.Split('/').Select(x => x.Contains("{") ? x : x.ToLower()));

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = swaggerDoc.Paths.ToDictionary(entry => LowercaseEverythingButParameters(entry.Key),
            entry => entry.Value);
        swaggerDoc.Paths = new OpenApiPaths();
        foreach (var (key, value) in paths)
        {
            swaggerDoc.Paths.Add(key, value);
        }
    }
}