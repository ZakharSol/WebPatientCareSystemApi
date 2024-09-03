using WebPatientCareSystemAPI.DTO;

namespace WebPatientCareSystemAPI.Repositories
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorListDTO>> GetDoctors(int page, int pageSize, string sortField, bool ascending);
        Task<DoctorEditDTO?> GetDoctorForEdit(int id);
        Task AddDoctor(DoctorEditDTO doctor);
        Task UpdateDoctor(DoctorEditDTO doctor);
        Task DeleteDoctor(int id);
    }
}
