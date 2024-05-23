namespace API.Extensions;
public static class AplicattionServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",builder=>
                builder.AllowAnyOrigin()   // withOrigins("https://domini.com")
                .AllowAnyMethod()           // withMethods("GET", "POST")
                .AllowAnyHeader());         // withHeaders(*accept*, "content-type")
        });
}