using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject1
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void ListPaqueteIsNotNull()
        {
            Correo correo = new Correo();


            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void IdRepetido()
        {
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("Quilmes", "1111");
            Paquete paquete2 = new Paquete("Capital", "1111");

            correo += paquete1;
            correo += paquete2;
        }
    }
}
