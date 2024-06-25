using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumDF.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly S19787Context _context;

        public VisitRepository(S19787Context context)
        {
            _context = context;
        }

        public async Task AddVisitAsync(Visit visit)
        {
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();
        }

        public async Task<Visit?> GetExistingVisitAsync(int idPatient, DateTime currentDate)
        {
            return await _context.Visits
                .FirstOrDefaultAsync(v => v.IdPatient == idPatient && v.Date > currentDate);
        }

        public async Task<int> GetDoctorVisitsCountAsync(int idDoctor, DateTime date)
        {
            return await _context.Visits
                .CountAsync(v => v.IdDoctor == idDoctor && v.Date.Date == date.Date);
        }

        public async Task<int> GetPatientVisitsCountAsync(int idPatient)
        {
            return await _context.Visits
                .CountAsync(v => v.IdPatient == idPatient);
        }
    }
}