using KolokwiumDF.Models;

namespace KolokwiumDF.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor?> GetDoctorAsync(int idDoctor);
    }
}