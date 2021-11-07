using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public interface IRepositoryComprobante : IRepository<data.Comprobante>
    {
        Task<IEnumerable<data.Comprobante>> GetAllAsync();
        Task<data.Comprobante> GetOneByIdAsync(int id);
    }
}
