using Countries.API.Endpoints;

namespace Countries.API.Extensions;

public static class HttpRequestPipelineExtensions
{

    public static WebApplication ConfigureHttpRequestPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(builder =>
            {
                builder
                    .WithOrigins("http://localhost:3000") // Replace with your React app's origin
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials() // If your React app needs to include credentials (e.g., cookies) in requests
                    .WithExposedHeaders("WWW-Authenticate"); // Add headers required for authentication
            });
        }

        app.UseHttpsRedirection();

        app.MapWelcomeEndpoints();

        app.MapCountriesEndpoints();

        return app;
    }
}
