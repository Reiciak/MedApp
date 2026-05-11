using System.Text.Json;
using System.Text.Json.Serialization;
using Backend.Models;
namespace Backend.Services;
public class PatientService
{
    private readonly List<Patient> _patients = new();

    public void AddPatient(Patient patient)
    {
        _patients.Add(patient);
    }

    public Patient? GetPatientById(Guid id)
    {
        return _patients.FirstOrDefault(p => p.Id == id);
    }

    public List<Patient> GetAllPatients()
    {
        return _patients;
    }

    public void LoadPatientsFromJson(string filePath)
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
            var item = JsonSerializer.Deserialize<PatientJsonDto>(json, options)
                       ?? throw new InvalidOperationException("Nie można zdeserializować danych pacjenta.");
            _patients.Add(MapToPatient(item));
            return;
        }
    }

    private static Patient MapToPatient(PatientJsonDto dto)
    {
        var id = Guid.TryParse(dto.PatientId, out var parsedId) ? parsedId : Guid.NewGuid();

        return new Patient
        {
            Id = id,
            Name = dto.PatientName ?? string.Empty,
            Surname = dto.PatientSurname ?? string.Empty,
        };
    }

    private class PatientJsonDto
    {
        [JsonPropertyName("patient_id")]
        public string? PatientId { get; set; }

        [JsonPropertyName("patient_name")]
        public string? PatientName { get; set; }

        [JsonPropertyName("patient_surname")]
        public string? PatientSurname { get; set; }
    }
}
