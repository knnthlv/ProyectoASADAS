using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
namespace DAL.Repository
{
    public interface IRepositoryAveria : IRepository<data.Averia>
    {
        Task<IEnumerable<data.Averia>> GetAllAsync();
        Task<data.Averia> GetOneByIdAsync(int id);
    }
}
