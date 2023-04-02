using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using Microsoft.Extensions.DependencyInjection;
using WebLab2;
using WebLab2.Data;
using WebLab2.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod();

    });
});

// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TestBaseDbContext>();
builder.Services.AddDbContext<TestBaseDbContext>();
builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var testBaseDbContext = scope.ServiceProvider.GetRequiredService<TestBaseDbContext>();
    await TestBaseDbContextSeed.SeedAsync(testBaseDbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

//try
//{
//    var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<TestBaseDbContext>();
//    DbInitializer.Initialize(context);
//}
//catch(Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}

app.Run();
