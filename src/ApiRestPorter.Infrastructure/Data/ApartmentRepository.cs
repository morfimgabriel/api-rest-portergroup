using ApiRestPorter.Core.Entities;
using ApiRestPorter.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPorter.Infrastructure.Data
{
    public class ApartmentRepository : EfRepository, IApartmentRepository
    {
        private readonly AppDbContext _dbContext;

        public ApartmentRepository(AppDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
