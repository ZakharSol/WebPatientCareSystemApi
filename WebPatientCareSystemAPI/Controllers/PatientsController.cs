using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPatientCareSystemAPI.Data;
using WebPatientCareSystemAPI.DTO;
using WebPatientCareSystemAPI.Models;
using WebPatientCareSystemAPI.Repositories;

namespace WebPatientCareSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "Lastname", [FromQuery] bool ascending = true)
        {
            var patients = await _patientService.GetPatients(page, pageSize, sortField, ascending);
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientForEdit(int id)
        {
            var patient = await _patientService.GetPatientForEdit(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientEditDTO patientDto)
        {
            await _patientService.AddPatient(patientDto);
            return CreatedAtAction(nameof(GetPatientForEdit), new { id = patientDto.Id }, patientDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientEditDTO patientDto)
        {
            if (id != patientDto.Id)
                return BadRequest();

            await _patientService.UpdatePatient(patientDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientService.DeletePatient(id);
            return NoContent();
        }
    }
}
