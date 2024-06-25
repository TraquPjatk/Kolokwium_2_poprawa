using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumDF.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly S19787Context _context;

        public ScheduleRepository(S19787Context context)
        {
            _context = context;
        }

        public async Task<Schedule?> GetDoctorScheduleAsync(int idDoctor, DateTime date)
        {
            return await _context.Schedules
                .FirstOrDefaultAsync(s => s.IdDoctor == idDoctor && s.DateFrom <= date && s.DateTo >= date);
        }
    }
}