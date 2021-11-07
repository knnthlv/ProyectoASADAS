using DAL.DO.Interfaces;
using data = DAL.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL;
using System.Threading.Tasks;

namespace BS
{
    public class TipoUsuario : ICRUD<data.TipoUsuario>
    {
        private readonly ADbContext db;

        public TipoUsuario(ADbContext _db)
        {
            db = _db;
        }

        public void Delete(data.TipoUsuario t)
        {
            new DAL.TipoUsuario(db).Delete(t);
        }

        public IEnumerable<data.TipoUsuario> GetAll()
        {
            return new DAL.TipoUsuario(db).GetAll();
        }

        public Task<IEnumerable<data.TipoUsuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.TipoUsuario GetOneById(int id)
        {
            return new DAL.TipoUsuario(db).GetOneById(id);
        }

        public Task<data.TipoUsuario> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<data.TipoUsuario> GetOneByIdAsyncString(string id)
        {
            throw new NotImplementedException();
        }

        public data.TipoUsuario GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.TipoUsuario t)
        {
            new DAL.TipoUsuario(db).Insert(t);
        }

        public void Update(data.TipoUsuario t)
        {
            new DAL.TipoUsuario(db).Update(t);
        }
    }
}
