using System;
using System.Collections.Generic;
using System.Text;

namespace Odin.Models.Base
{
    /// <summary>
    /// Base class for the implementation of models
    /// </summary>
    /// <typeparam name="TId">Property that identified this Class</typeparam>
    public abstract class EntityBase<TId> : EntityBaseWithTypedId<TId>
    {
        /// <summary>
        /// Date of creation of the record
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Date of update of the record
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Default constructor, create a new object with CreatedOn and UpdatedOn dates using DateTime.Now
        /// </summary>
        public EntityBase()
        {
            CreatedOn = DateTime.UtcNow.AddHours(-5);
            UpdatedOn = DateTime.UtcNow.AddHours(-5);
        }
    }
}
