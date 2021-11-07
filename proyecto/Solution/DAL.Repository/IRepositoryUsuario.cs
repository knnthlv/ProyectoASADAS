using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryUsuario : IRepository<data.Usuario>
    {
        Task<IEnumerable<data.Usuario>> GetAllAsync();
        Task<data.Usuario> GetOneByIdAsyncString(string id);
    }
}