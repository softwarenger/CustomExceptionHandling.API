using CustomExceptionHandlingMiddleware.API;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();
//app.UseExceptionHandler(
//    options =>
//    {
//        options.Run(
//            async context =>
//            {
//                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//                context.Response.ContentType = "text/html";
//                var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
//                if (null != exceptionObject)
//                {
//                    var errorMessage = $"{exceptionObject.Error.Message}";
//                    await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
//                }
//            });
//    }
//);

app.UseAuthorization();

app.MapControllers();

app.Run();
