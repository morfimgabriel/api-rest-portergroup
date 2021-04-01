using ApiRestPorter.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRestPorter.Core.Interfaces
{
    public interface IResidentRepository : IRepository
    {
        Task<List<Resident>> ListAsync(int apartmentId);

        Task<Resident> GetByIdAsync(int id);
    }
}
