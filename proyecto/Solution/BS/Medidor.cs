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
    public class Medidor : ICRUD<data.Medidor>
    {
        private readonly ADbContext db;

        public Medidor(ADbContext _db)
        {
            db = _db;
        }

        public void Delete(data.Medidor t)
        {
            new DAL.Medidor(db).Delete(t);
        }

        public IEnumerable<data.Medidor> GetAll()
        {
            return new DAL.Medidor(db).GetAll();
        }

        public Task<IEnumerable<data.Medidor>> GetAllAsync()
        {
            return new DAL.Medidor(db).GetAllAsync();
        }

        public data.Medidor GetOneById(int id)
        {
            return new DAL.Medidor(db).GetOneById(id);
        }

        public Task<data.Medidor> GetOneByIdAsync(int id)
        {
            return new DAL.Medidor(db).GetOneByIdAsync(id);
        }

        public Task<data.Medidor> GetOneByIdAsyncString(string id)
        {
            throw new NotImplementedException();
        }

        public data.Medidor GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Medidor t)
        {
            new DAL.Medidor(db).Insert(t);
        }

        public void Update(data.Medidor t)
        {
            new DAL.Medidor(db).Update(t);
        }
    }
}
