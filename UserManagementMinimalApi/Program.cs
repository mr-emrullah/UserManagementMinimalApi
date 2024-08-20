using Microsoft.AspNetCore.Diagnostics;
using UserManagementPresentation;
using UserManagementPresentation.Controllers;
using UserManagementPresentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadPresentation(); // UserEndpoints'i servis olarak ekliyoruz

builder.Services.AddScoped<GlobalExceptionHandler>();



var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandler = context.RequestServices.GetRequiredService<GlobalExceptionHandler>();
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerFeature != null)
        {
            await exceptionHandler.TryHandleAsync(context, exceptionHandlerFeature.Error, context.RequestAborted);
        }
    });
});

// UserManagementPresentation'daki controller'ları kullanarak yapılandırın
app.MapPresentationLayer();



app.Run();