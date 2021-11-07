using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public class RepositoryTarjeta : Repository<data.Tarjeta>, IRepositoryTarjeta
    {
        public RepositoryTarjeta(ADbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Tarjeta>> GetAllAsync()
        {
            return await _db.Tarjeta
                .Include(m => m.CedulaNavigation)
                .Include(m => m.IdMarcaNavigation)
                .ToListAsync();
        }

        public async Task<data.Tarjeta> GetOneByIdAsyncString(string id)
        {
            return await _db.Tarjeta
                .Include(m => m.CedulaNavigation)
                .Include(m => m.IdMarcaNavigation)
                .SingleAsync(m => m.NumeroTarjeta == id); //Llave primaria de la tabla
        }

        private ADbContext _db
        {
            get { return dbContext as ADbContext; }
        }
    }
}
