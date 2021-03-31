using ApiRestPorter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestPorter.Core.Interfaces
{
    public interface IResidentRepository : IRepository
    {
        Task<List<Resident>> ListAsync(int apartmentId);
    }
}
