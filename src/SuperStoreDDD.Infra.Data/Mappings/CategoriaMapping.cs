using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperStoreDDD.Domain.Entities;

namespace SuperStoreDDD.Infra.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Denominacao)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(c => c.Codigo)
                .HasColumnType("int")
                .IsRequired();

            //1:N => Categoria - Produto
            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);

            builder.ToTable("Categorias");
        }
    }
}