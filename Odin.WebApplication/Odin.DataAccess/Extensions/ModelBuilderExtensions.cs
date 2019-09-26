using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Odin.DataAccess.Extensions
{
    /// <summary>
    /// Extensions used for model building
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Avoids the table pluralizing 
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
