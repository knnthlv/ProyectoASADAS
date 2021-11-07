using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryMedidor : IRepository<data.Medidor>
    {
        Task<IEnumerable<data.Medidor>> GetAllAsync();
        Task<data.Medidor> GetOneByIdAsync(int id);
    }
}
