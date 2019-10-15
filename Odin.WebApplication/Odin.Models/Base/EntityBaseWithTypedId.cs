using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.Models.Base
{
    /// <summary>
    /// Base class for the implementation of models
    /// </summary>
    /// <typeparam name="TId">Property that identified this Class</typeparam>
    public abstract class EntityBaseWithTypedId<TId> : IEntityWithTypedId<TId>
    {
        public virtual TId Id { get; set; }
    }
}
