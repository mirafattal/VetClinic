using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL.Models;

namespace Vet_DAL._GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DbSet<T> _dbSet;
        public readonly VetClinicContext _vetClinicContext;

        public GenericRepository(VetClinicContext vetClinicContext)
        {
            _vetClinicContext = vetClinicContext;
            _dbSet = _vetClinicContext.Set<T>();
        }
        public T Add(T t)
        {
            var result = _dbSet.Add(t);
            _vetClinicContext.SaveChanges();
            return t;

        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T Update(T t)
        {
            _dbSet.Update(t);
            try
            {
                _vetClinicContext.SaveChanges();

            }
            catch
            {

            }
            return t;
        }
        public bool Delete(T t)
        {
            _dbSet.Remove(t);
            try
            {
                _vetClinicContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            var entity = GetById(id);

            return Delete(entity);

        }
    }
}
