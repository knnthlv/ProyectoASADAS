using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryUsuario : Repository<data.Usuario>, IRepositoryUsuario
    {
        public RepositoryUsuario(ADbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Usuario>> GetAllAsync()
        {
            return await _db.Usuario
                .Include(m => m.IdUsuarioNavigation)
                .ToListAsync();
        }

        public async Task<data.Usuario> GetOneByIdAsyncString(string id)
        {
            return await _db.Usuario
                .Include(m => m.IdUsuarioNavigation)
                .SingleAsync(m => m.Cedula == id); //Llave primaria de la tabla
        }
        public async Task<data.Usuario> GetOneByIdAsyncStringLogin(string correo, string password)
        {
            return await _db.Usuario
                .Include(m => m.IdUsuarioNavigation)
                .Where(x => x.Correo == correo && x.Password == password).FirstOrDefaultAsync();
        }

        private ADbContext _db
        {
            get { return dbContext as ADbContext; }
        }
    }
}
