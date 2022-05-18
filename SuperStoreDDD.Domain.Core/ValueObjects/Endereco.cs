using SuperStoreDDD.Domain.Core.Enums;
using SuperStoreDDD.Domain.Core.ValueObjectBases.Base;

namespace SuperStoreDDD.Domain.Core.ValueObjects
{
    public class Endereco : ValueObjectBase
    {
        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public int Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public EnumUF Estado { get; private set; }

        public Endereco(string CEP, string logradouro, string complemento, int numero, string bairro, string cidade, EnumUF estado)
        {
            this.CEP = CEP;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CEP;
            yield return Logradouro;
            yield return Complemento;
            yield return Numero;
            yield return Bairro;
            yield return Cidade;
            yield return Estado;
        }
    }
}