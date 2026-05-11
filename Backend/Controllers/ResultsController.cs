
using Backend.Services;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResultsController : ControllerBase
{
    private readonly ResultsService _resultsService;
    private readonly PatientService _patientService;

    public ResultsController(ResultsService resultsService, PatientService patientService)
    {
        _resultsService = resultsService;
        _patientService = patientService;
    }

    [HttpGet]
    [Route("results")]
    public ActionResult<IEnumerable<Result>> GetAllResults()
    {
         return Ok(_resultsService.GetAllResults());
    }

    [HttpGet]
    [Route("patients")]
    public ActionResult<IEnumerable<Patient>> GetAllPatients()
    {
        return Ok( _patientService.GetAllPatients());
    }
}