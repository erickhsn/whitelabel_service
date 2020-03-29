using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Whitelabel.Service.Domain.Entities;
using Whitelabel.Service.Domain.Interfaces.Repository;
using Whitelabel.Service.Domain.Interfaces.Services;

namespace Whitelabel.Service.APP.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Post<V>(T entity) where V : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<V>());

            _repository.Insert(entity);
            return entity;
        }

        public T Put<V>(T entity) where V : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<V>());

            _repository.Update(entity);
            return entity;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            _repository.Delete(id);
        }

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");
            var element = _repository.Get(id);
            if (element.Equals(null))
                throw new NullReferenceException("Record not Found!");

            return element;
        }

        public IList<T> GetAll() => _repository.GetAll();

        private void Validate(T entity, AbstractValidator<T> validator)
        {
            if (entity == null)
                throw new Exception("Records not found!");

            validator.ValidateAndThrow(entity);
        }
    }
}
