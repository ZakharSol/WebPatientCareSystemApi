namespace WebPatientCareSystemAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public int? CabinetId { get; set; }
        public Cabinet? Cabinet { get; set; }
        public int? SpecializationId { get; set; }
        public Specialization? Specialization { get; set; }
        public int? DistrictId { get; set; }
        public District? District { get; set; }
    }
}
