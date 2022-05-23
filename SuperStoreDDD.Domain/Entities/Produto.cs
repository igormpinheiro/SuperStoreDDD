using Flunt.Notifications;
using Flunt.Validations;
using SuperStoreDDD.Domain.Core.Entities;

namespace SuperStoreDDD.Domain.Entities
{
    public class Produto : EntidadeAuditavel<int>
    {
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public string Descricao { get; private set; }
        public string Denominacao { get; private set; }
        public int CategoriaId { get; private set; }

        public Produto(decimal preco, int quantidadeEstoque, string descricao, string denominacao, int categoriaId, string usuario) : base(usuario)
        {
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Descricao = descricao;
            Denominacao = denominacao;
            CategoriaId = categoriaId;
        }

        protected override void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Denominacao, "Denominacao", "Denominacao deve ser informado.")
                .IsNotNull(Descricao, "Descricao", "Descricao deve ser informado.")
                .IsNotNull(CategoriaId, "CategoriaId", "CategoriaId deve ser informado.")
                .IsGreaterThan(CategoriaId, 0, "CategoriaId", "CategoriaId deve ser informado.")
                .IsGreaterThan(Preco, 0, "Preco", "Preco deve ser informado.")
            );
        }
    }
}