using System;
using System.Collections.Generic;
using System.Text;
using Whitelabel.Service.Domain.Entities;

namespace Whitelabel.Service.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);

        T Get(int id);

        IList<T> GetAll();
    }
}
