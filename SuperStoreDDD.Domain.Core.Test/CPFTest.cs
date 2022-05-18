using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperStoreDDD.Domain.Core.ValueObjects;

namespace SuperStoreDDD.Domain.Core.Test
{
    [TestClass]
    public class CPFTest
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("Abc")]
        [DataRow("932.233.231-05")]
        [DataRow("93223323105")]
        [DataRow("932 233 231 05")]
        public void Ao_criar_um_CPF_Invalido_DEVE_retornar_um_erro_de_validacao(string value)
        {
            var cpf = new CPF(value);

            Assert.AreEqual(false, cpf.IsValid);
        }

        [TestMethod]
        [DataRow("932.233.231-04")]
        [DataRow("93223323104")]
        [DataRow("932 233 231 04")]
        [DataRow("932233231-04")]
        public void Ao_criar_um_CPF_valido_DEVE_passar_pela_validacao(string value)
        {
            var cpf = new CPF(value);

            Assert.AreEqual(true, cpf.IsValid);
        }
    }
}