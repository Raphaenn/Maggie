using App.Services;
using Maggie.App.Interfaces;
using Maggie.App.Services;
using Maggie.App.Services;
using Maggie.Domain.Interfaces.Repository;
using Maggie.Domain.Services;
using Maggie.Infrastructure.Data.PostgresConnect;
using Maggie.Infrastructure.Repository;
using Maggie.Middlewares;

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

// Users Scope
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<UserServiceBase>();

// Budget Scope
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<IBudgetAppService, BudgetAppService>();
builder.Services.AddScoped<BudgetService>();

builder.Services.AddScoped<IBudgetToUserRepository, BudgetToUserRepository>();
builder.Services.AddScoped<BudgetToUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();