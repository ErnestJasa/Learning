using LoginTutorial.Data;
using LoginTutorial.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<UserContext>(options => 
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddCors();

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

app.UseAuthorization();

app.UseCors(options => options
    .WithOrigins(new[] {"http://localhost:3000"} )
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.MapControllers();

app.Run();
