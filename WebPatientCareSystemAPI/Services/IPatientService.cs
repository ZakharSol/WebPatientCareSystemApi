using WebPatientCareSystemAPI.DTO;


namespace WebPatientCareSystemAPI.Repositories
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientListDTO>> GetPatients(int page, int pageSize, string sortField, bool ascending);
        Task<PatientEditDTO?> GetPatientForEdit(int id);
        Task AddPatient(PatientEditDTO patient);
        Task UpdatePatient(PatientEditDTO patient);
        Task DeletePatient(int id);
    }
}
