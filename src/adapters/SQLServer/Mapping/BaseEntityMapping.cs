using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SQLServer.Mapping
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id).IsClustered();

            ApplyBuilder(builder);

        }

        protected abstract void ApplyBuilder(EntityTypeBuilder<T> builder);
    }
}
