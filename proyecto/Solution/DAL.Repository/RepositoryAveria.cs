using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryAveria : Repository<data.Averia>, IRepositoryAveria
    {
        public RepositoryAveria(ADbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Averia>> GetAllAsync()
        {
            return await _db.Averia
                .Include(m => m.IdEstadoNavigation)
                .ToListAsync();
        }

        public async Task<data.Averia> GetOneByIdAsync(int id)
        {
            return await _db.Averia
                .Include(m => m.IdEstadoNavigation)
                .SingleAsync(m => m.IdAveria == id); //Llave primaria de la tabla
        }

        private ADbContext _db
        {
            get { return dbContext as ADbContext; }
        }
    }
}
