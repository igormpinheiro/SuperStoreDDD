using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperStoreDDD.Domain.Core.ValueObjects;
using SuperStoreDDD.Domain.Entities;

namespace SuperStoreDDD.Domain.Test
{
    [TestClass]
    public class ClienteTest
    {
        

        [TestMethod]
        public void Ao_criar_um_Usario_com_Nome_Invalido_DEVE_retornar_um_erro_de_validacao()
        {
            var nomeCompleto = new NomeCompleto("", "");
            var cliente = new Cliente(nomeCompleto, null, null, null);
            
            Assert.AreEqual(false, cliente.IsValid);
        }
        [TestMethod]
        public void Ao_criar_um_Usario_com_parametros_Null_DEVE_retornar_um_erro_de_validacao()
        {
            var cliente = new Cliente(null, null, null, null);

            Assert.AreEqual(false, cliente.IsValid);
            Assert.AreEqual(4, cliente.Notifications.Count);
        }


    }
}