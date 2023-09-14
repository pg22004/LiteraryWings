using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiteraryWings.AccesoADatos;
using LiteraryWings.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraryWings.AccesoADatos.Tests
{
    [TestClass()]
    public class SugerenciaDALTests
    {
        private static Sugerencia sugerenciaInicial = new Sugerencia { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var sugerencia = new Sugerencia();
            sugerencia.Nombre = "Elissa";
            sugerencia.Correo = "Elissa123@gmail.com";
            sugerencia.Comentario = "Algunos libros no se encuentran";
            int result = await SugerenciaDAL.CrearAsync(sugerencia);
            Assert.AreNotEqual(0, result);
            sugerenciaInicial.Id = sugerencia.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var sugerencia = new Sugerencia();
            sugerencia.Id = sugerenciaInicial.Id;
            sugerencia.Nombre = "Eli";
            sugerencia.Correo = "Eli23@gmail.com";
            sugerencia.Comentario = "Libros no encontrados";
            int result = await SugerenciaDAL.ModificarAsync(sugerencia);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var sugerencia = new Sugerencia();
            sugerencia.Id = sugerenciaInicial.Id;
            var resultSugerencia = await SugerenciaDAL.ObtenerPorIdAsync(sugerencia);
            Assert.AreEqual(sugerencia.Id, resultSugerencia.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultSugerencias = await SugerenciaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultSugerencias.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var sugerencia = new Sugerencia();
            sugerencia.Nombre = "e";
            sugerencia.Top_Aux = 10;
            var resultSugerencias = await SugerenciaDAL.BuscarAsync(sugerencia);
            Assert.AreNotEqual(0, resultSugerencias.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var sugerencia = new Sugerencia();
            sugerencia.Id = sugerenciaInicial.Id;
            int result = await SugerenciaDAL.EliminarAsync(sugerencia);
            Assert.AreNotEqual(0, result);
        }
    }
}