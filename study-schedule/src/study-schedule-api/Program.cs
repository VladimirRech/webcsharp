using Microsoft.EntityFrameworkCore;
using study_schedule_api.DbContexts;
// using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// IConfiguration configuration = new ConfigurationManager();

// Reading String Connectiong
string connString = builder.Configuration.GetConnectionString("TasksConnString");

builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("TasksConnString")));

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
