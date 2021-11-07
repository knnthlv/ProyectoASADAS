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
    public class Averia : ICRUD<data.Averia>
    {
        private readonly ADbContext db;

        public Averia(ADbContext _db)
        {
            db = _db;
        }

        public void Delete(data.Averia t)
        {
            new DAL.Averia(db).Delete(t);
        }

        public IEnumerable<data.Averia> GetAll()
        {
            return new DAL.Averia(db).GetAll();
        }

        public Task<IEnumerable<data.Averia>> GetAllAsync()
        {
            return new DAL.Averia(db).GetAllAsync();
        }

        public data.Averia GetOneById(int id)
        {
            return new DAL.Averia(db).GetOneById(id);
        }

        public Task<data.Averia> GetOneByIdAsync(int id)
        {
            return new DAL.Averia(db).GetOneByIdAsync(id);
        }

        public Task<data.Averia> GetOneByIdAsyncString(string id)
        {
            throw new NotImplementedException();
        }

        public data.Averia GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Averia t)
        {
            new DAL.Averia(db).Insert(t);
        }

        public void Update(data.Averia t)
        {
            new DAL.Averia(db).Update(t);
        }
    }
}
