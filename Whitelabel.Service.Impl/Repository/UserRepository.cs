using System;
using System.Collections.Generic;
using System.Text;
using Whitelabel.Service.Domain.Entities;
using Whitelabel.Service.Domain.Interfaces.Repository;
using Whitelabel.Service.Impl.Context;

namespace Whitelabel.Service.Impl.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WhitelabelContext context) : base (context)
        {
        }

    }
}
