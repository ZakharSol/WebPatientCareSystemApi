using Microsoft.AspNetCore.Mvc;
using WebPatientCareSystemAPI.Repositories;
using WebPatientCareSystemAPI.DTO;

namespace WebPatientCareSystemAPI.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortField = "Fullname", [FromQuery] bool ascending = true)
        {
            var doctors = await _doctorService.GetDoctors(page, pageSize, sortField, ascending);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorForEdit(int id)
        {
            var doctor = await _doctorService.GetDoctorForEdit(id);
            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorEditDTO doctorDTO)
        {
            await _doctorService.AddDoctor(doctorDTO);
            return CreatedAtAction(nameof(GetDoctorForEdit), new { id = doctorDTO.Id }, doctorDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorEditDTO doctorDTO)
        {
            if (id != doctorDTO.Id)
                return BadRequest();

            await _doctorService.UpdateDoctor(doctorDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteDoctor(id);
            return NoContent();
        }
    }
}
