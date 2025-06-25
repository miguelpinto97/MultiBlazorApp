using Microsoft.EntityFrameworkCore;
using MultiBlazorApp.Data;
using MultiBlazorApp.Data.Services;
using System.Reflection;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
}, ServiceLifetime.Scoped);

builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(ParametroService)));


builder.Services.AddScoped<IParametroService, ParametroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    context.Database.Migrate();
}

app.Run();
