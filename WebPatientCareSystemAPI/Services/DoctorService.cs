using Microsoft.EntityFrameworkCore;
using WebPatientCareSystemAPI.Data;
using WebPatientCareSystemAPI.DTO;
using WebPatientCareSystemAPI.Models;

namespace WebPatientCareSystemAPI.Repositories
{
    public class DoctorService : IDoctorService
    {
        private readonly WebPatientCareSystemAPIContext _context;

        public DoctorService(WebPatientCareSystemAPIContext context)
        {
            _context = context;
        }

        // Asynchronously retrieves a list of doctors with pagination and sorting options
        public async Task<IEnumerable<DoctorListDTO>> GetDoctors(int page, int pageSize, string sortField, bool ascending)
        {
            var query = _context.Doctors
                                .Include(d => d.Cabinet)
                                .Include(d => d.Specialization)
                                .Include(d => d.District)
                                .AsQueryable();

            switch (sortField.ToLower())
            {
                case "fullname":
                    query = ascending ? query.OrderBy(d => d.Fullname) : query.OrderByDescending(d => d.Fullname);
                    break;
                case "cabinet":
                    query = ascending ? query.OrderBy(d => d.Cabinet) : query.OrderByDescending(d => d.Cabinet);
                    break;
                case "specialization":
                    query = ascending ? query.OrderBy(d => d.Specialization) : query.OrderByDescending(d => d.Specialization);
                    break;
                case "district":
                    query = ascending ? query.OrderBy(d => d.District) : query.OrderByDescending(d => d.District);
                    break;
                default:
                    query = ascending ? query.OrderBy(d => d.Fullname) : query.OrderByDescending(d => d.Fullname);
                    break;
            }

            return await query.Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .Select(d => new DoctorListDTO
                              {
                                  Id = d.Id,
                                  FullName = d.Fullname,
                                  Cabinet = d.Cabinet,
                                  Specialization = d.Specialization,
                                  District = d.District
                              }).ToListAsync();
        }

        // Asynchronously retrieves a doctor for editing by ID
        public async Task<DoctorEditDTO?> GetDoctorForEdit(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return null;

            return new DoctorEditDTO
            {
                Id = doctor.Id,
                FullName = doctor.Fullname,
                CabinetId = doctor.CabinetId,
                SpecializationId = doctor.SpecializationId,
                DistrictId = doctor.DistrictId
            };
        }

        // Asynchronously adds a new doctor to the database
        public async Task AddDoctor(DoctorEditDTO doctorDTO)
        {
            var doctor = new Doctor
            {
                Fullname = doctorDTO.FullName,
                CabinetId = doctorDTO.CabinetId,
                SpecializationId = doctorDTO.SpecializationId,
                DistrictId = doctorDTO.DistrictId
            };
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        // Asynchronously updates an existing patient in the database
        public async Task UpdateDoctor(DoctorEditDTO doctorDTO)
        {
            var doctor = await _context.Doctors.FindAsync(doctorDTO.Id);
            if (doctor == null) return;

            doctor.Fullname = doctorDTO.FullName;
            doctor.CabinetId = doctorDTO.CabinetId;
            doctor.SpecializationId = doctorDTO.SpecializationId;
            doctor.DistrictId = doctorDTO.DistrictId;

            await _context.SaveChangesAsync();
        }

        // Asynchronously deletes a patient from the database by ID
        public async Task DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }

    }
}
