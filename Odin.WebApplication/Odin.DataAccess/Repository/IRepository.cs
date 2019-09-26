using Odin.DataAccess.Base;
using Odin.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.DataAccess.Repository
{
    public interface IRepository<T, TId> : IRepositoryWithTypedId<T, TId>
        where T : class, IEntityWithTypedId<TId>
    {
    }
}
