using KolokwiumDF.DTOs;
using KolokwiumDF.Repositories;

namespace KolokwiumDF.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDto?> GetPatientWithVisitsAsync(int idPatient)
        {
            var patient = await _patientRepository.GetPatientWithVisitsAsync(idPatient);

            if (patient == null)
            {
                return null;
            }

            var totalAmountSpent = patient.Visits.Sum(v => v.Price);
            var numberOfVisits = patient.Visits.Count;

            var patientDto = new PatientDto
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate,
                TotalAmountMoneySpent = $"{totalAmountSpent} zł",
                NumberOfVisits = numberOfVisits,
                Visits = patient.Visits.Select(v => new VisitDto
                {
                    IdVisit = v.IdVisit,
                    Doctor = $"{v.IdDoctorNavigation.FirstName} {v.IdDoctorNavigation.LastName}",
                    Date = v.Date,
                    Price = v.Price
                }).ToList()
            };

            return patientDto;
        }
    }
}