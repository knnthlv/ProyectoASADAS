using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryTarjeta : IRepository<data.Tarjeta>
    {
        Task<IEnumerable<data.Tarjeta>> GetAllAsync();
        Task<data.Tarjeta> GetOneByIdAsyncString(string id);
    }
}
