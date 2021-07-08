using DataAccess.Contract;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
   public class Repository<T> //: IRepository<T> where T : Entity
    {
        //protected readonly RepositoryContext _context;
        //public Repository(RepositoryContext context)
        //{
        //    _context = context;
        //}
        //public async Task Add(T entity)
        //{
        //    await _context.Set<T>().AddAsync(entity);
        //}

        //public async Task<IEnumerable<T>> GetAll()
        //{
        //    return await Task.Run(() => _context.Set<T>().ToList());
        //}

        //public Task<IEnumerable<T>> GetAll(string procedureName)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<T> GetById(int id)
        //{
        //    return await _context.Set<T>().FindAsync(id);
        //}
    }
}
