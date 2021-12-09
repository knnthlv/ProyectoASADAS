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
    public class Usuario : ICRUD<data.Usuario>
    {
        private RepositoryUsuario repo;

        public Usuario(ADbContext _db)
        {
            repo = new RepositoryUsuario(_db);
        }

        public void Delete(data.Usuario t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Usuario> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Usuario>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Usuario GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Usuario> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Usuario> GetOneByIdAsyncString(string id)
        {
            return repo.GetOneByIdAsyncString(id);
        }
          public Task<data.Usuario> GetOneByIdAsyncStringLogin(string correo, string password)
        {
            return repo.GetOneByIdAsyncStringLogin(correo,password);
        }

        public data.Usuario GetOneByIdString(string id)
        {
            return repo.GetOnebyIDString(id);
        }



        public void Insert(data.Usuario t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Usuario t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
