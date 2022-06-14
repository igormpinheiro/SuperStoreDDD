using Flunt.Notifications;
using Flunt.Validations;
using SuperStoreDDD.Domain.Core.Entities;

namespace SuperStoreDDD.Domain.Entities
{
    public class Categoria : Entidade<int>
    {
        public int Codigo { get; private set; }
        public string Denominacao { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; }

        public Categoria(int codigo, string denominacao)
        {
            Codigo = codigo;
            Denominacao = denominacao;
            Validar();
        }
        public Categoria(int codigo, string denominacao, IEnumerable<Produto> produtos)
        {
            Denominacao = denominacao;
            Produtos = produtos;
            Validar();
        }

        protected override void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerOrEqualsThan(Codigo, 0, "Código", "Código deve ser informado.")
                .IsNullOrEmpty(Denominacao, "Nome", "Nome deve ser informado.")
            );
        }

        public override string ToString()
        {
            return "{Denominacao} - {Codigo}";
        }
    }
}