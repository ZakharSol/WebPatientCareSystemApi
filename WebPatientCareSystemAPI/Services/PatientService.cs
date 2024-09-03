using WebPatientCareSystemAPI.DTO;
using WebPatientCareSystemAPI.Models;
using WebPatientCareSystemAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WebPatientCareSystemAPI.Repositories
{
    public class PatientService : IPatientService
    {
        private readonly WebPatientCareSystemAPIContext _context;

        public PatientService(WebPatientCareSystemAPIContext context)
        {
            _context = context;
        }

        // Asynchronously retrieves a list of patients with pagination and sorting options
        public async Task<IEnumerable<PatientListDTO>> GetPatients(int page, int pageSize, string sortField, bool ascending)
        {
            var query = _context.Patients.Include(p => p.District).AsQueryable();

            switch (sortField.ToLower())
            {
                case "firstname":
                    query = ascending ? query.OrderBy(p => p.Firstname) : query.OrderByDescending(p => p.Firstname);
                    break;
                case "lastname":
                    query = ascending ? query.OrderBy(p => p.Lastname) : query.OrderByDescending(p => p.Lastname);
                    break;
                case "patronymic":
                    query = ascending ? query.OrderBy(p => p.Patronymic) : query.OrderByDescending(p => p.Patronymic);
                    break;
                case "birthday":
                    query = ascending ? query.OrderBy(p => p.Birthday) : query.OrderByDescending(p => p.Birthday);
                    break;
                case "districtnumber":
                    query = ascending ? query.OrderBy(p => p.District) : query.OrderByDescending(p => p.District);
                    break;
                default:
                    query = ascending ? query.OrderBy(p => p.Lastname) : query.OrderByDescending(p => p.Lastname);
                    break;
            }

            return await query.Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .Select(p => new PatientListDTO
                              {
                                  Id = p.Id,
                                  Firstname = p.Firstname,
                                  Lastname = p.Lastname,
                                  Patronymic = p.Patronymic,
                                  Birthday = p.Birthday
                              }).ToListAsync();
        }

        // Asynchronously retrieves a patient for editing by ID    
        public async Task<PatientEditDTO?> GetPatientForEdit(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return null;

            return new PatientEditDTO
            {
                Id = patient.Id,
                Firstname = patient.Firstname,
                Lastname = patient.Lastname,
                Patronymic = patient.Patronymic,
                Address = patient.Address,
                Birthday = patient.Birthday,
                Gender = patient.Gender,
                DistrictId = patient.DistrictId
            };
        }

        // Asynchronously adds a new patient to the database
        public async Task AddPatient(PatientEditDTO patientDTO)
        {
            var patient = new Patient
            {
                Firstname = patientDTO.Firstname,
                Lastname = patientDTO.Lastname,
                Patronymic = patientDTO.Patronymic,
                Address = patientDTO.Address,
                Birthday = patientDTO.Birthday,
                Gender = patientDTO.Gender,
                DistrictId = patientDTO.DistrictId
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        // Asynchronously updates an existing patient in the database
        public async Task UpdatePatient(PatientEditDTO patientDTO)
        {
            var patient = await _context.Patients.FindAsync(patientDTO.Id);
            if (patient == null) return;

            patient.Firstname = patientDTO.Firstname;
            patient.Lastname = patientDTO.Lastname;
            patient.Patronymic = patientDTO.Patronymic;
            patient.Address = patientDTO.Address;
            patient.Birthday = patientDTO.Birthday;
            patient.Gender = patientDTO.Gender;
            patient.DistrictId = patientDTO.DistrictId;

            await _context.SaveChangesAsync();
        }

        // Asynchronously deletes a patient from the database by ID
        public async Task DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
