using Flunt.Notifications;
using Flunt.Validations;
using SuperStoreDDD.Domain.Core.Entities;

namespace SuperStoreDDD.Domain.Entities
{
    public class CupomDesconto : EntidadeAuditavel<Guid>
    {
        public string Codigo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public bool Ativo { get; private set; } = false;
        public int IdProduto { get; private set; }
        public virtual Produto Produto { get; private set; }

        public readonly decimal DescontoMaximo = 0.2m;

        public CupomDesconto(string codigo, decimal valor, DateTime dataInicio, DateTime dataFim, int idProduto, Produto produto, string usuario) : base(usuario)
        {
            Codigo = codigo;
            Valor = valor;
            DataInicio = dataInicio;
            DataFim = dataFim;
            IdProduto = produto.Id;
            Produto = produto;
            Validar();

            if (!IsValid)
                return;
            
            if (DataInicio <= DateTime.Now && DataFim >= DateTime.Now)
                Ativo = true;
        }
        
        public void DesativarCupom()
        {
            Ativo = false;
        }

        protected override void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Codigo, "Nome", "Nome deve ser informado.")
                .IsNotNull(Valor, "Valor", "Valor deve ser informado.")
                .IsLowerThan(Valor, DescontoMaximo, "Valor", "Valor deve ser menor que 20%.")
                .IsNotNull(DataInicio, "DataInicio", "DataInicio deve ser informado.")
                .IsGreaterOrEqualsThan(DataInicio, DateTime.Now, "DataInicio", "DataInicio deve ser maior ou igual a data atual.")
                .IsGreaterOrEqualsThan(DataFim, DataInicio, "DataFim", "DataFim deve ser maior ou igual a data DataInicio.")
                .IsNotNull(DataFim, "DataFim", "DataFim deve ser informado.")
                .IsNotNull(Produto, "Produto", "Produto deve ser informado.")
            );
        }
    }
}
