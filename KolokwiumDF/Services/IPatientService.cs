using KolokwiumDF.DTOs;

namespace KolokwiumDF.Services
{
    public interface IPatientService
    {
        Task<PatientDto?> GetPatientWithVisitsAsync(int idPatient);
    }
}