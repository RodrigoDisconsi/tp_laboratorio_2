using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using Clases_Instanciables;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]

        public void TestDniInvalidoException()
        {
            Alumno alumno = new Alumno(1, "Rodri", "Perez", "23234sadas", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]

        public void TestNacionalidadInvalidaException()
        {
            Alumno alumno = new Alumno(1, "Rodri", "Perez", "99999999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]

        public void TestDniEsperado()
        {
            string dni = "1111";
            int esperado = 1111;
            Alumno alumno = new Alumno(1, "Rodri", "Perez", dni, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.AreEqual(esperado, alumno.DNI);
        }

        [TestMethod]
        public void TestAtributosNull()
        {
            Alumno alumno = new Alumno(1, "Rodri", "Perez", "1111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.IsNotNull(alumno.Nacionalidad);
        }
    }
}
