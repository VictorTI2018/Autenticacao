using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SQLServer.Mapping
{
    public class UserEntityMapping : BaseEntityMapping<UserEntity>
    {
        protected override void ApplyBuilder(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar");

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar");

        }
    }
}
