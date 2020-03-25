using System;
using System.Collections.Generic;
using System.Text;
using Whitelabel.Service.Domain.Entities;
using Whitelabel.Service.Domain.Interfaces.Repository;
using Whitelabel.Service.Impl.Context;

namespace Whitelabel.Service.Impl.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly WhitelabelContext _context;

        public BaseRepository(WhitelabelContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IList<T> getAll()
        {
            throw new NotImplementedException();
        }

        public async void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
