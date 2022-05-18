using SuperStoreDDD.Domain.Core.Entities;

namespace SuperStoreDDD.Domain.Entities
{
    public class Categoria : Entidade<int>
    {
        public string Denominacao { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; }

        public Categoria(string denominacao, IEnumerable<Produto> produtos)
        {
            Denominacao = denominacao;
            Produtos = produtos;
            Validar();
        }

        protected override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}