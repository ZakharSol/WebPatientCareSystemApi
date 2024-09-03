using WebPatientCareSystemAPI.Models;

namespace WebPatientCareSystemAPI.DTO
{
    public class DoctorListDTO
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public Cabinet? Cabinet { get; set; }
        public Specialization? Specialization { get; set; }
        public District? District { get; set; }
    }
}
