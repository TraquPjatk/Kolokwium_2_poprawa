using KolokwiumDF.Models;

namespace KolokwiumDF.Repositories
{
    public interface IScheduleRepository
    {
        Task<Schedule?> GetDoctorScheduleAsync(int idDoctor, DateTime date);
    }
}