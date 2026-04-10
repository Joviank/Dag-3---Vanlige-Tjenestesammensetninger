using Microsoft.EntityFrameworkCore;
using TaskServiceClass = TaskService.TaskService;
using TaskService.Api.Data;
using TaskService.Api.Repositories;
using TaskService.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHealthChecks();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default")
                      ?? Environment.GetEnvironmentVariable("ConnectionStrings__Default");

builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ITaskRepository, EfTaskRepository>();
builder.Services.AddScoped<TaskServiceClass>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapHealthChecks("/health");
app.Urls.Add("http://0.0.0.0:80");

app.Run();