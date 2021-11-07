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
    public class Usuario : ICRUD<data.Usuario>
    {
        private readonly ADbContext db;

        public Usuario(ADbContext _db)
        {
            db = _db;
        }

        public void Delete(data.Usuario t)
        {
            new DAL.Usuario(db).Delete(t);
        }

        public IEnumerable<data.Usuario> GetAll()
        {
            return new DAL.Usuario(db).GetAll();
        }

        public Task<IEnumerable<data.Usuario>> GetAllAsync()
        {
            return new DAL.Usuario(db).GetAllAsync();
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
            return new DAL.Usuario(db).GetOneByIdAsyncString(id);
        }

        public data.Usuario GetOneByIdString(string id)
        {
            return new DAL.Usuario(db).GetOneByIdString(id);
        }

        public void Insert(data.Usuario t)
        {
            new DAL.Usuario(db).Insert(t);
        }

        public void Update(data.Usuario t)
        {
            new DAL.Usuario(db).Update(t);
        }
    }
}
