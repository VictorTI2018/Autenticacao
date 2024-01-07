using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SQLServer.Mapping
{
    public class CategoriasEntityMapping : BaseEntityMapping<CategoriasEntity>
    {
        protected override void ApplyBuilder(EntityTypeBuilder<CategoriasEntity> builder)
        {
            builder.ToTable("Categorias");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar");

        }
    }
}
