using KolokwiumDF.Models;

namespace KolokwiumDF.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient?> GetPatientAsync(int idPatient);
        Task<Patient?> GetPatientWithVisitsAsync(int idPatient);
    }
}