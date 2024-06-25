using KolokwiumDF.Models;
using KolokwiumDF.Repositories;

namespace KolokwiumDF.Services
{
    public class VisitService : IVisitService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public VisitService(IPatientRepository patientRepository, IVisitRepository visitRepository,
            IDoctorRepository doctorRepository, IScheduleRepository scheduleRepository)
        {
            _patientRepository = patientRepository;
            _visitRepository = visitRepository;
            _doctorRepository = doctorRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<int?> AddVisitAsync(int idPatient, int idDoctor, DateTime date)
        {
            var patient = await _patientRepository.GetPatientAsync(idPatient);
            if (patient == null)
            {
                return null;
            }

            var doctor = await _doctorRepository.GetDoctorAsync(idDoctor);
            if (doctor == null)
            {
                return null;
            }

            var existingVisit = await _visitRepository.GetExistingVisitAsync(idPatient, DateTime.Now);
            if (existingVisit != null)
            {
                return null;
            }

            var schedule = await _scheduleRepository.GetDoctorScheduleAsync(idDoctor, date);
            if (schedule == null)
            {
                return null;
            }

            var doctorVisitsOnDate = await _visitRepository.GetDoctorVisitsCountAsync(idDoctor, date);
            if (doctorVisitsOnDate > 5)
            {
                return null;
            }

            var visitPrice = doctor.PriceForVisit;
            var patientVisitsCount = await _visitRepository.GetPatientVisitsCountAsync(idPatient);
            if (patientVisitsCount > 10)
            {
                visitPrice *= 0.9m;
            }

            var visit = new Visit
            {
                IdPatient = idPatient,
                IdDoctor = idDoctor,
                Date = date,
                Price = visitPrice
            };

            await _visitRepository.AddVisitAsync(visit);
            return visit.IdVisit;
        }
    }
}
