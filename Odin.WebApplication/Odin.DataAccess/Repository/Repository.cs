using Microsoft.EntityFrameworkCore;
using Odin.DataAccess.Base;
using Odin.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.DataAccess.Repository
{
    public class Repository<T, TId> : RepositoryWithTypedId<T, TId>, IRepository<T, TId>
        where T : class, IEntityWithTypedId<TId>
    {
        public Repository(DbContext context) : base(context)
        {

        }
    }
}
