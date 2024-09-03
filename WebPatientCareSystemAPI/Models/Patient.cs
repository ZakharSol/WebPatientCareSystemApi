using System.ComponentModel.DataAnnotations;

namespace WebPatientCareSystemAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Patronymic { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public int? DistrictId { get; set; }
        public District? District { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}