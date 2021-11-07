using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoUsuario : ICRUD<data.TipoUsuario>
    {
        private Repository<data.TipoUsuario> repo;

        public TipoUsuario(ADbContext _db)
        {
            repo = new Repository<data.TipoUsuario>(_db);
        }

        public void Delete(data.TipoUsuario t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.TipoUsuario> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.TipoUsuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.TipoUsuario GetOneById(int id)
        {
            return repo.GetOnebyID(id);
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
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.TipoUsuario t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
