using Flunt.Notifications;
using Flunt.Validations;
using SuperStoreDDD.Domain.Core.Entities;
using SuperStoreDDD.Domain.Core.Interfaces;

namespace SuperStoreDDD.Domain.Entities
{
    public class Produto : EntidadeAuditavel<int>, IAggregateRoot
    {
        public string Denominacao { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public bool Ativo { get; private set; }
        public string Imagem { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }

        protected Produto()
        { }

        public Produto(string denominacao, string descricao, decimal preco, int quantidadeEstoque, string imagem, string usuario) : base(usuario)
        {
            Denominacao = denominacao;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Imagem = imagem;
        }

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0)
                quantidade *= -1;

            if (QuantidadeEstoque < quantidade)
                AddNotification("QuantidadeEstoque", "Não há estoque suficiente para realizar a operação");

            QuantidadeEstoque -= quantidade;
        }

        public void CreditarEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
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