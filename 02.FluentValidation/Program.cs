using _02.FluentValidation.Models.DTO;
using _02.FluentValidation.Models.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Yazmýþ olduðumuz Validations'larýn çalýþmasý için gerekli kodlar.  
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters(); 

builder.Services.AddScoped<IValidator<CreateStudentRequestDto>, CreateStudentRequestDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateStudentRequestDto>, UpdateStudentRequestDtoValidator>();
builder.Services.AddScoped<IValidator<CreateUniversityRequestDto>, CreateUniversityRequestDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateUniversityRequestDto>, UpdateUniversityRequestDtoValidator>();

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
