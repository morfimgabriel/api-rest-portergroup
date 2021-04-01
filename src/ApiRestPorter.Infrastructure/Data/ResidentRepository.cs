using ApiRestPorter.Core.Entities;
using ApiRestPorter.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPorter.Infrastructure.Data
{
    public class ResidentRepository : EfRepository, IResidentRepository
    {
        private readonly AppDbContext _dbContext;

        public ResidentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Resident> GetByIdAsync(int id)
        {
            return _dbContext.Set<Resident>().Include(r => r.Apartment).SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Resident>> ListAsync(int apartmentId)
        {
            return await _dbContext.Residents
                .Where<Resident>(r => r.ApartmentId == apartmentId || apartmentId == 0)
                .Include(r => r.Apartment)
                .ToListAsync();
        }

    }
}
