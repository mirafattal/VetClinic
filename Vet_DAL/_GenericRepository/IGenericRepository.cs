using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_DAL._GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T t);
        T Update(T t);
        public bool Delete(int id);
        bool Delete(T t);
    }
}
