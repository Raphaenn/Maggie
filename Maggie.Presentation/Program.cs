using Maggie.App.Interfaces;
using Maggie.App.Services;
using Maggie.App.Services;
using Maggie.Domain.Interfaces.Repository;
using Maggie.Domain.Services;
using Maggie.Infrastructure.Data.PostgresConnect;
using Maggie.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PostgresContext>(_ => 
{
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new PostgresContext(connectionString);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<UserServiceBase>();

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

app.Run();