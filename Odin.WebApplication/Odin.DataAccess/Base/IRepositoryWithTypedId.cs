using Microsoft.EntityFrameworkCore.Storage;
using Odin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DataAccess.Base
{
    /// <summary>
    /// Interface with the CRUD contracts
    /// </summary>
    /// <typeparam name="T">Model class where the CRUD operations will be executed</typeparam>
    /// <typeparam name="TId">Class Identificator type</typeparam>
    public interface IRepositoryWithTypedId<T, in TId> where T : IEntityWithTypedId<TId>
    {
        /// <summary>
        /// Allows the Query actions
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Query();

        /// <summary>
        /// Adds an element asynchronously
        /// </summary>
        /// <param name="Entity">Object to add</param>
        Task AddAsync(T Entity);

        /// <summary>
        /// Updates an especific element
        /// </summary>
        /// <param name="Entity">Object to update</param>
        void Update(T Entity);

        /// <summary>
        /// Begins the transaction
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();

        /// <summary>
        /// Save model changes asynchronously
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Deletes an element
        /// </summary>
        /// <param name="Entity">Object to remove from the context</param>
        void Remove(T Entity);

        /// <summary>
        /// Deletes a list of elements
        /// </summary>
        /// <param name="Entities">Objects to remove from the context</param>
        void RemoveRange(IList<T> Entities);
    }
}
