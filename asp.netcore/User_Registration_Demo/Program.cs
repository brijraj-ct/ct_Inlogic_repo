using User_Registration_Demo.Infrastructure.Context;
using User_Registration_Demo.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using User_Registration_Demo.Infrastructure.Models;
using User_Registration_Demo.IOC.ServiceRegistration;
using Microsoft.AspNetCore.Identity;

/// <summary>
/// Initializes a new instance of the <see cref="$Program"/> class.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.RegisterService();

var provider = builder.Services.BuildServiceProvider();

var config = provider.GetRequiredService<IConfiguration>();

builder.Services.AddDbContext<UserRegistrationContext>(x => x.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<Users, IdentityRole>()
    .AddEntityFrameworkStores<UserRegistrationContext>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


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

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
