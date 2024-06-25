using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumDF.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly S19787Context _context;

        public PatientRepository(S19787Context context)
        {
            _context = context;
        }

        public async Task<Patient?> GetPatientAsync(int idPatient)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.IdPatient == idPatient);
        }

        public async Task<Patient?> GetPatientWithVisitsAsync(int idPatient)
        {
            return await _context.Patients
                .Include(p => p.Visits)
                .ThenInclude(v => v.IdDoctorNavigation)
                .FirstOrDefaultAsync(p => p.IdPatient == idPatient);
        }
    }
}