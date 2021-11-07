using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryComprobante : Repository<data.Comprobante>, IRepositoryComprobante
    {
        public RepositoryComprobante(ADbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Comprobante>> GetAllAsync()
        {
            return await _db.Comprobante
                .Include(m => m.CedulaNavigation)
                .Include(m => m.IdReciboNavigation)
                .Include(m => m.NumeroTarjetaNavigation)
                .ToListAsync();
        }

        public async Task<data.Comprobante> GetOneByIdAsync(int id)
        {
            return await _db.Comprobante
                .Include(m => m.CedulaNavigation)
                .Include(m => m.IdReciboNavigation)
                .Include(m => m.NumeroTarjetaNavigation)
                .SingleAsync(m => m.IdComprobante == id); //Llave primaria de la tabla
        }

        private ADbContext _db
        {
            get { return dbContext as ADbContext; }
        }
    }
}
