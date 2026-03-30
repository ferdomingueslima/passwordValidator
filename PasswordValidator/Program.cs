using PasswordValidator.Domain.Rules.Implementations;
using PasswordValidator.Domain.Rules;
using PasswordValidator.Application.UseCases;
using PasswordValidator.Application.UseCases.Implamentations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordRule, MinLengthRule>();
builder.Services.AddScoped<IPasswordRule, UppercaseRule>();
builder.Services.AddScoped<IPasswordRule, LowercaseRule>();
builder.Services.AddScoped<IPasswordRule, DigitRule>();
builder.Services.AddScoped<IPasswordRule, SpecialCharacterRule>();
builder.Services.AddScoped<IPasswordRule, RepeatedCharacterRule>();
builder.Services.AddScoped<IPasswordValidation, PasswordValidation>();

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
