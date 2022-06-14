using SuperStoreDDD.Domain.Core.ValueObjectBases.Base;

namespace SuperStoreDDD.Domain.Core.ValueObjects
{
    public class Email : ValueObjectBase
    {
        public string Endereco { get; private set; }

        public Email(string endereco)
        {
            Endereco = endereco;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Endereco;
        }
    }
}