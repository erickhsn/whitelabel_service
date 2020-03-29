using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Whitelabel.Service.APP.Services;
using Whitelabel.Service.Domain.Interfaces.Repository;
using Whitelabel.Service.Domain.Interfaces.Services;
using Whitelabel.Service.Impl.Repository;

namespace Whitelabel.Service.CrossCutting.IoC
{
    public class DependencyInjection
    {
        private readonly IServiceCollection _service;

        public DependencyInjection(IServiceCollection service)
        {
            _service = service;
        }

        public void RegisterServices()
        {
            _service.AddScoped<IUserService, UserService>();
        }
        public void RegisterRepositories()
        {
            _service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
