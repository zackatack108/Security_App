using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security_API.Controllers;
using Security_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SecurityContext>(options => options.UseNpgsql(builder.Configuration["dbConnection"]));
builder.Services.AddSingleton<UserController>(new UserController( builder.Configuration["dbConnection"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );

app.UseAuthorization();

app.MapControllers();

app.Run();
