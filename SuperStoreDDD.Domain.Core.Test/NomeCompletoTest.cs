using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperStoreDDD.Domain.Core.ValueObjects;

namespace SuperStoreDDD.Domain.Core.Test
{
    [TestClass]
    public class NomeCompletoTest
    {
        [TestMethod]
        [DataRow("", "")]
        [DataRow(null, null)]
        [DataRow("123", "123")]
        [DataRow("0123456789012345678901234567890123456789", "0123456789012345678901234567890123456789")]
        public void Ao_criar_um_NomeCompleto_invalido_DEVE_retornar_um_erro_de_validacao(string nome, string sobrenome)
        {
            var nomeCompleto = new NomeCompleto(nome, sobrenome);

            Assert.AreEqual(false, nomeCompleto.IsValid);
            Assert.AreEqual(2, nomeCompleto.Notifications.Count);
        }

        [TestMethod]
        public void Ao_criar_um_NomeCompleto_respeitando_regras_DEVE_passar_pela_validacao()
        {
            var nomeCompleto = new NomeCompleto("1234", "1234");

            Assert.AreEqual(true, nomeCompleto.IsValid);
        }
    }
}