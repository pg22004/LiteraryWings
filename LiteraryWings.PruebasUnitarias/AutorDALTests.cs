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
    public class AutorDALTests
    {
        private static Autor autorInicial = new Autor { Id = 22 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var autor = new Autor();
            autor.Nombre = "Edgar";
            autor.Apellido = "Allan Poe";
            autor.AutorImagen = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fes.m.wikipedia.org%2Fwiki%2FArchivo%3AEdgar_Allan_Poe_portrait_B.jpg&psig=AOvVaw1Suo1Sn3mEWFNqr4XS_Ilc&ust=1694663332101000&source=images&cd=vfe&opi=89978449&ved=0CBAQjRxqFwoTCLjY_InXpoEDFQAAAAAdAAAAABAD";
            autor.Seudonimo = "Allan Poe";
            autor.FechaNacimiento = "1999-06-12";
            autor.Nacionalidad = "Estadounidense";
            int result = await AutorDAL.CrearAsync(autor);
            Assert.AreNotEqual(0, result);
            autorInicial.Id = autor.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var autor = new Autor();
            autor.Id = autorInicial.Id;
            autor.Nombre = "Allan";
            autor.Apellido = "Poe";
            autor.AutorImagen = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fhistoria.nationalgeographic.com.es%2Fa%2Fedgar-allan-poe-maestro-terror_14764&psig=AOvVaw1Suo1Sn3mEWFNqr4XS_Ilc&ust=1694663332101000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCLjY_InXpoEDFQAAAAAdAAAAABAI";
            autor.Seudonimo = "Allan Poe";
            autor.FechaNacimiento = "12-06-1999";
            autor.Nacionalidad = "Boston, Massachusetts";
            int result = await AutorDAL.ModificarAsync(autor);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var autor = new Autor();
            autor.Id = autorInicial.Id;
            var resultAutor = await AutorDAL.ObtenerPorIdAsync(autor);
            Assert.AreEqual(autor.Id, resultAutor.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultAutor = await AutorDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultAutor.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var autor = new Autor();
            autor.Nombre = "a";
            autor.Apellido = "p";
            autor.Top_Aux = 10;
            var resultAutor = await AutorDAL.BuscarAsync(autor);
            Assert.AreNotEqual(0, resultAutor.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var autor = new Autor();
            autor.Id = autorInicial.Id;
            int result = await AutorDAL.EliminarAsync(autor);
            Assert.AreNotEqual(0, result);
        }
    }
}