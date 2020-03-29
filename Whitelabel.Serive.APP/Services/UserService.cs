using System;
using System.Collections.Generic;
using System.Text;
using Whitelabel.Service.Domain.Entities;
using Whitelabel.Service.Domain.Interfaces.Repository;
using Whitelabel.Service.Domain.Interfaces.Services;

namespace Whitelabel.Service.APP.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository) {}

    }
}
