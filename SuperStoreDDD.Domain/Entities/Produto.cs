using SuperStoreDDD.Domain.Core.Entities;

namespace SuperStoreDDD.Domain.Entities
{
    public class Produto : EntidadeAuditavel<int>
    {
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public string Descricao { get; private set; }
        public string Denominacao { get; private set; }
        public Produto(decimal preco, int quantidadeEstoque, string descricao, string denominacao, string usuario) : base(usuario)
        {
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Descricao = descricao;
            Denominacao = denominacao;
        }

        protected override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}