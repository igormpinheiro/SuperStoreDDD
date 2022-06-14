using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperStoreDDD.Domain.Entities;

namespace SuperStoreDDD.Infra.Data.Mappings
{
    internal class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Denominacao)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.QuantidadeEstoque)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Imagem)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(p => p.CriadoPor)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.ModificadoPor)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DataModificacao)
                .HasColumnType("datetime")
                .IsRequired();

            builder.ToTable("Produtos");
        }
    }
}