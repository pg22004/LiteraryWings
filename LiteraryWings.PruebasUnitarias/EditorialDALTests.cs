using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiteraryWings.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteraryWings.EntidadesDeNegocio;

namespace LiteraryWings.AccesoADatos.Tests
{
    [TestClass()]
    public class EditorialDALTests
    {
        private static Editorial editorialInicio = new Editorial { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var editorial = new Editorial();
            editorial.Nombre = "Administrador";
            int result = await EditorialDAL.CrearAsync(editorial);
            Assert.AreNotEqual(0, result);
            editorialInicio.Id = editorial.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var editorial = new Editorial();
            editorial.Id = editorialInicio.Id;
            editorial.Nombre = "Admin";
            int result = await EditorialDAL.ModificarAsync(editorial);
            Assert.AreNotEqual(0, result); ;
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var editorial = new Editorial();
            editorial.Id = editorialInicio.Id;
            var resultEditorial = await EditorialDAL.ObtenerPorIdAsync(editorial);
            Assert.AreEqual(editorial.Id, resultEditorial.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultEditorial = await EditorialDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultEditorial.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var editorial = new Editorial();
            editorial.Nombre = "a";
            editorial.Top_aux = 10;
            var resultEditorial = await EditorialDAL.BuscarAsync(editorial);
            Assert.AreNotEqual(0, resultEditorial.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var editorial = new Editorial();
            editorial.Id = editorialInicio.Id;
            int result = await EditorialDAL.EliminarAsync(editorial);
            Assert.AreNotEqual(0, result);
        }
    }
}