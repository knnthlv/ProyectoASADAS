using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryRecibo : IRepository<data.Recibo>
    {
        Task<IEnumerable<data.Recibo>> GetAllAsync();
        Task<data.Recibo> GetOneByIdAsync(int id);
    }
}
