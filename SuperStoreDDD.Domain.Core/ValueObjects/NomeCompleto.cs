using Flunt.Notifications;
using Flunt.Validations;
using SuperStoreDDD.Domain.Core.ValueObjectBases.Base;

namespace SuperStoreDDD.Domain.Core.ValueObjects
{
    public class NomeCompleto : ValueObjectBase
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        public NomeCompleto(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Validar();
        }

        public override void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome","O nome deve ser informado" )
                .IsLowerThan(Nome, 40, "Nome", "Name should have no more than 40 chars")
                .IsGreaterThan(Nome, 3, "Nome", "Name should have at least 3 chars")
                .IsNotNullOrEmpty(Sobrenome, "Sobrenome", "O Sobrenome deve ser informado")
                .IsLowerThan(Sobrenome, 40, "Sobrenome", "Sobrenome should have no more than 40 chars")
                .IsGreaterThan(Sobrenome, 3, "Sobrenome", "Sobrenome should have at least 3 chars")
            );
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Nome;
            yield return Sobrenome;
        }
    }
}