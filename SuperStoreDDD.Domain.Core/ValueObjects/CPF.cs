using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using SuperStoreDDD.Domain.Core.ValueObjectBases.Base;

namespace SuperStoreDDD.Domain.Core.ValueObjects
{
    public class CPF : ValueObjectBase
    {
        public string Numero { get; private set; }

        public CPF(string numero)
        {
            this.Numero = numero;
            RemoveMascara();
            Validar();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Numero;
        }

        public override void Validar()
        {
            AddNotifications(new Contract<Notification>()
                .IsCpf(Numero, "CPF", "CPF inválido"));
        }

        private void RemoveMascara()
        {
            if (!String.IsNullOrEmpty(Numero))
                Numero = Numero.Replace(".", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty);
        }
    }
}