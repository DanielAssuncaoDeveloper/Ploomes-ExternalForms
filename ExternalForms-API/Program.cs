using ExternalForms_API.Extensions;
using ExternalForms_API.HandlerExceptions;
using ExternalForms_Data.Database;
using ExternalForms_Data.Repositories;
using ExternalForms_Domain.Agreements.Repositories;
using ExternalForms_Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Inicializando conex�o com banco de dados
builder.Services.AddScoped(x => 
    new DatabaseConnection(
        builder.Configuration.GetConnectionString("ExternalForms") ?? "")
    );

builder.Services.ResolveDependencies();

builder.Services.AddControllers();

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
app.UseProblemDetailsExceptionHandler();
app.UseAuthorization();
app.MapControllers();
app.Run();
