using KolokwiumDF.Models;

namespace KolokwiumDF.Repositories
{
    public interface IVisitRepository
    {
        Task AddVisitAsync(Visit visit);
        Task<Visit?> GetExistingVisitAsync(int idPatient, DateTime currentDate);
        Task<int> GetDoctorVisitsCountAsync(int idDoctor, DateTime date);
        Task<int> GetPatientVisitsCountAsync(int idPatient);
    }
}