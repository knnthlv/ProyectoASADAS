using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryMedidor : Repository<data.Medidor>, IRepositoryMedidor
    {
        public RepositoryMedidor(ADbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Medidor>> GetAllAsync()
        {
            return await _db.Medidor
                .Include(m => m.CedulaNavigation)
                .ToListAsync();
        }

        public async Task<data.Medidor> GetOneByIdAsync(int id)
        {
            return await _db.Medidor
                .Include(m => m.CedulaNavigation)
                .SingleAsync(m => m.IdMedidor == id); //Llave primaria de la tabla
        }

        private ADbContext _db
        {
            get { return dbContext as ADbContext; }
        }
    }
}
