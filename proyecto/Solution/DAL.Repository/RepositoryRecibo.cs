using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryRecibo : Repository<data.Recibo>, IRepositoryRecibo
    {
        public RepositoryRecibo(ADbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Recibo>> GetAllAsync()
        {
            return await _db.Recibo
                .Include(m => m.CedulaNavigation)
                .Include(m => m.IdEstadoNavigation)
                .Include(m => m.IdMedidorNavigation)
                .ToListAsync();
        }

        public async Task<data.Recibo> GetOneByIdAsync(int id)
        {
            return await _db.Recibo
                .Include(m => m.CedulaNavigation)
                .Include(m => m.IdEstadoNavigation)
                .Include(m => m.IdMedidorNavigation)
                .SingleAsync(m => m.IdRecibo == id); //Llave primaria de la tabla
        }

        private ADbContext _db
        {
            get { return dbContext as ADbContext; }
        }
    }
}
