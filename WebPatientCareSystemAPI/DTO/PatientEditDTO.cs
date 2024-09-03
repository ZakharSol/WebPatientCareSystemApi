using System.ComponentModel.DataAnnotations;
using WebPatientCareSystemAPI.Models;

namespace WebPatientCareSystemAPI.DTO
{
    public class PatientEditDTO
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
    }
}
