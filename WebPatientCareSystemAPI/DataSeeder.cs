using WebPatientCareSystemAPI.Data;
using WebPatientCareSystemAPI.Models;

namespace WebPatientCareSystemAPI
{
    public class DataSeeder
    {
        public static void Seed(WebPatientCareSystemAPIContext context)
        {
            Random rand = new Random();
            var itemIndex = rand.Next(5, 20);
            for (int i = 1; i < itemIndex; i++)
            {
                var cab = new Cabinet { Number = $"Cabinet{i}" };
                context.Cabinets.AddRange(cab);

                var dist = new District { Number = $"District{i}" };
                context.Districts.AddRange(dist);

                var spec = new Specialization { Name = $"Specialization{i}" };
                context.Specializations.AddRange(spec);

                context.SaveChanges();

                var pat = new Patient { Firstname = $"Firstname{i}", Lastname = $"Lastname{i}", Patronymic = $"Patronymic{i}", Address = $"Address{i}", Birthday = DateTime.UtcNow.Date, Gender = (Gender)new Random().Next(0, 1), DistrictId = dist.Id };
                context.Patients.AddRange(pat);

                var doc = new Doctor { Fullname = $"Fullname{i}", CabinetId = cab.Id, SpecializationId = spec.Id, DistrictId = dist.Id };
                context.Doctors.AddRange(doc);
                context.SaveChanges();
            }
        }
        public static void Clear(WebPatientCareSystemAPIContext context)
        {
            context.Patients.RemoveRange(context.Patients);
            context.Doctors.RemoveRange(context.Doctors);
            context.Specializations.RemoveRange(context.Specializations);
            context.Cabinets.RemoveRange(context.Cabinets);
            context.Districts.RemoveRange(context.Districts);

            context.SaveChanges();
        }
    }
}
