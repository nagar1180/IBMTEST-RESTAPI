using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
   public interface IRepository<T> where T: Entity
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAll(string procedureName);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}
