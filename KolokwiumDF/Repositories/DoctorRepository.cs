using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumDF.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly S19787Context _context;

        public DoctorRepository(S19787Context context)
        {
            _context = context;
        }

        public async Task<Doctor?> GetDoctorAsync(int idDoctor)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == idDoctor);
        }
    }
}