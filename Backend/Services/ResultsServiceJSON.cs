using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Backend.Models;

namespace Backend.Services;

public class ResultsService
{
    private readonly List<Result> _results = new List<Result>();

    public void AddResult(Result result)
    {
        _results.Add(result);
    }

    public Result? GetResultById(Guid id)
    {
        return _results.FirstOrDefault(r => r.Id == id);
    }

    public List<Result> GetAllResults()
    {
        return _results;
    }

    public void LoadResultsFromJson(string filePath)
    {
        if (!File.Exists(filePath)){
            throw new FileNotFoundException($"File {filePath} does not exist.");
        }

        string json = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        if (json.TrimStart().StartsWith("{"))
        {
            var item = JsonSerializer.Deserialize<ResultJsonDto>(json, options)
                       ?? throw new InvalidOperationException("Nie można zdeserializować danych wyniku.");
            _results.Add(MapToResult(item));
            return;
        }
    }

    private static Result MapToResult(ResultJsonDto dto)
    {
        var id = Guid.NewGuid();

        return new Result
        {
            Id = id,
            PatientId = Guid.TryParse(dto.PatientId, out var patientId) ? patientId : Guid.NewGuid(),
            TestName = dto.TestName ?? string.Empty,
            ResultValue = dto.Result,
            Scale = dto.Scale ?? string.Empty,
        };
    }

    private class ResultJsonDto
    {
        [JsonPropertyName("patient_id")]
        public string? PatientId { get; set; }
        
        [JsonPropertyName("result")]
        public double Result { get; set; }

        [JsonPropertyName("test_name")]
        public string? TestName { get; set; }

        [JsonPropertyName("scale")]
        public string? Scale { get; set; }
    }

}
