using Flunt.Notifications;
using Flunt.Validations;
using SuperStoreDDD.Domain.Core.Entities;

namespace SuperStoreDDD.Domain.Entities
{
    public class Categoria : Entidade<int>
    {
        public string Denominacao { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; }

        public Categoria(string denominacao)
        {
            Denominacao = denominacao;
            Validar();
        }
        public Categoria(string denominacao, IEnumerable<Produto> produtos)
        {
            Denominacao = denominacao;
            Produtos = produtos;
            Validar();
        }

        protected override void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNullOrEmpty(Denominacao, "Nome", "Nome deve ser informado.")
            );
        }
    }
}