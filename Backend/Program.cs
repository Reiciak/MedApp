using Backend.Services;
using Backend.Controllers;
using Backend.Models;
using System.ComponentModel.DataAnnotations;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutterWeb", policy =>
    {
        policy
            .SetIsOriginAllowed(origin =>
            {
                if (!Uri.TryCreate(origin, UriKind.Absolute, out var uri))
                {
                    return false;
                }

                return uri.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase)
                       || uri.Host.Equals("127.0.0.1", StringComparison.OrdinalIgnoreCase);
            })
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<PatientService>();
builder.Services.AddSingleton<ResultsService>();

var app = builder.Build();

var patientService = app.Services.GetRequiredService<PatientService>();
var resultsService = app.Services.GetRequiredService<ResultsService>();
try
{
    var rootPath = Path.GetFullPath(Path.Combine(app.Environment.ContentRootPath, ".."));
    var labFiles = Directory.GetFiles(rootPath, "Lab_*.json", SearchOption.TopDirectoryOnly)
        .Concat(Directory.GetFiles(rootPath, "Lab_*.txt", SearchOption.TopDirectoryOnly))
        .OrderBy(path => path)
        .ToList();

    foreach (var filePath in labFiles)
    {
        patientService.LoadPatientsFromJson(filePath);
        resultsService.LoadResultsFromJson(filePath);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error occurred while loading results: {ex.Message}");
}

app.MapGet("/api/results", (ResultsService resultsService) => {
    return Results.Ok(resultsService.GetAllResults());
});

app.MapGet("/api/patients", (PatientService patientService) => {
    return Results.Ok(patientService.GetAllPatients());
});


app.UseCors("AllowFlutterWeb");
app.MapControllers();
app.MapScalarApiReference();
app.MapGet("/", () => "Hello world!");

app.Run();
