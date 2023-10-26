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
    public class LibroDALTests
    {
        private static Libro libroInicial = new Libro { Id = 4, IdAutor = 1, IdCategoria = 1, IdEditorial = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var libro = new Libro();
            libro.Nombre = "El mar de los monstruos";
            libro.FechaLanzamiento = "2008-05-06";
            libro.IdAutor = libroInicial.IdAutor;
            libro.IdCategoria = libroInicial.IdCategoria;
            libro.IdEditorial = libroInicial.IdEditorial;
            libro.Idioma = "Inglés";
            libro.Paginas = 100;
            libro.Descripcion = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo";
            libro.Descripcion2 = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto. Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto.";
            libro.ImagenPortada = "https://mega.nz/file/wfIASIKZ#Jgq5JJQcESfe8zskRlynsb8HeeNvgHxXehYIATzajU4";
            libro.LinkDescarga = "https://mega.nz/file/lDh32baB#BfP7xbRubeAzJvLVqJ-wvpieffypoUjGxYXfm0xr55w";
            libro.ImagenIntroduccion = "https://mega.nz/file/seh2xRIK#oLKvKl5UB3whCb0wcxl7ibfulmAlbXyUIYnNjsAr5Jk";
            int result = await LibroDAL.CrearAsync(libro);
            Assert.AreNotEqual(0, result);
            libroInicial.Id = libro.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var libro = new Libro();
            libro.Id = libroInicial.Id;
            libro.Nombre = "El mar de los monstruos - Rick Riordan";
            libro.FechaLanzamiento = "2008-05-06";
            libro.IdAutor = libroInicial.IdAutor;
            libro.IdCategoria = libroInicial.IdCategoria;
            libro.IdEditorial = libroInicial.IdEditorial;
            libro.Idioma = "Español";
            libro.Paginas = 248;
            libro.Descripcion = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento";
            libro.Descripcion2 = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto. Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto.";
            libro.ImagenPortada = "https://mega.nz/file/wfIASIKZ#Jgq5JJQcESfe8zskRlynsb8HeeNvgHxXehYIATzajU4";
            libro.LinkDescarga = "https://mega.nz/file/lDh32baB#BfP7xbRubeAzJvLVqJ-wvpieffypoUjGxYXfm0xr55w";
            libro.ImagenIntroduccion = "https://mega.nz/file/seh2xRIK#oLKvKl5UB3whCb0wcxl7ibfulmAlbXyUIYnNjsAr5Jk";
            int result = await LibroDAL.ModificarAsync(libro);
            Assert.AreNotEqual(0, result);
        }

        
        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var libro = new Libro();
            libro.Id = libroInicial.Id;
            var resultMunicipios = await LibroDAL.ObtenerPorIdAsync(libro);
            Assert.AreEqual(libro.Id, resultMunicipios.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultLibros = await LibroDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultLibros.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var libro = new Libro();
            libro.Nombre = "El mar de los monstruos - Rick Riordan";
            libro.FechaLanzamiento = "2008-05-06";
            libro.IdAutor = libroInicial.IdAutor;
            libro.IdCategoria = libroInicial.IdCategoria;
            libro.IdEditorial = libroInicial.IdEditorial;
            libro.Idioma = "Español";
            libro.Paginas = 248;
            libro.Descripcion = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento";
            libro.Descripcion2 = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto. Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto.";
            libro.ImagenPortada = "https://mega.nz/file/wfIASIKZ#Jgq5JJQcESfe8zskRlynsb8HeeNvgHxXehYIATzajU4";
            libro.LinkDescarga = "https://mega.nz/file/lDh32baB#BfP7xbRubeAzJvLVqJ-wvpieffypoUjGxYXfm0xr55w";
            libro.ImagenIntroduccion = "https://mega.nz/file/seh2xRIK#oLKvKl5UB3whCb0wcxl7ibfulmAlbXyUIYnNjsAr5Jk";
            libro.top_aux = 10;
            var resultLibros = await LibroDAL.BuscarAsync(libro);
            Assert.AreNotEqual(0, resultLibros.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirLLavesAsyncTest()
        {
            var libro = new Libro();
            libro.Nombre = "El mar de los monstruos - Rick Riordan";
            libro.FechaLanzamiento = "2008-05-06";
            libro.IdAutor = libroInicial.IdAutor;
            libro.IdCategoria = libroInicial.IdCategoria;
            libro.IdEditorial = libroInicial.IdEditorial;
            libro.Idioma = "Español";
            libro.Paginas = 248;
            libro.Descripcion = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento";
            libro.Descripcion2 = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto. Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto.";
            libro.ImagenPortada = "https://mega.nz/file/wfIASIKZ#Jgq5JJQcESfe8zskRlynsb8HeeNvgHxXehYIATzajU4";
            libro.LinkDescarga = "https://mega.nz/file/lDh32baB#BfP7xbRubeAzJvLVqJ-wvpieffypoUjGxYXfm0xr55w";
            libro.ImagenIntroduccion = "https://mega.nz/file/seh2xRIK#oLKvKl5UB3whCb0wcxl7ibfulmAlbXyUIYnNjsAr5Jk";
            libro.top_aux = 10;
            var resultLibros = await LibroDAL.BuscarIncluirLLavesAsync(libro);
            Assert.AreNotEqual(0, resultLibros.Count);
            var ultimoLibro = resultLibros.FirstOrDefault();
            Assert.IsTrue(ultimoLibro.Autor != null && libro.IdAutor == ultimoLibro.Autor.Id);//No lo deje completo.
        }

        //[TestMethod()]
        //public async Task T7BuscarIncluirCategoriaAsyncTest()
        //{
        //    var libro = new Libro();
        //    libro.Nombre = "El mar de los monstruos - Rick Riordan";
        //    //libro.FechaLanzamiento = 2008-05-06;
        //    libro.IdAutor = libroInicial.IdAutor;
        //    libro.IdCategoria = libroInicial.IdCategoria;
        //    libro.IdEditorial = libroInicial.IdEditorial;
        //    libro.Idioma = "Español";
        //    libro.Paginas = 248;
        //    libro.Descripcion = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto.";
        //    libro.ImagenPortada = "https://mega.nz/file/wfIASIKZ#Jgq5JJQcESfe8zskRlynsb8HeeNvgHxXehYIATzajU4";
        //    libro.LinkDescarga = "https://mega.nz/file/lDh32baB#BfP7xbRubeAzJvLVqJ-wvpieffypoUjGxYXfm0xr55w";
        //    libro.ImagenIntroduccion = "https://mega.nz/file/seh2xRIK#oLKvKl5UB3whCb0wcxl7ibfulmAlbXyUIYnNjsAr5Jk";
        //    libro.top_aux = 10;
        //    var resultLibros = await LibroDAL.BuscarIncluirCategoriaAsync(libro);
        //    Assert.AreNotEqual(0, resultLibros.Count);
        //    var ultimoLibro = resultLibros.FirstOrDefault();
        //    Assert.IsTrue(ultimoLibro.Categoria != null && libro.IdCategoria == ultimoLibro.Categoria.id);
        //}

        //[TestMethod()]
        //public async Task T8BuscarIncluirEditorialAsyncTest()
        //{
        //    var libro = new Libro();
        //    libro.Nombre = "El mar de los monstruos - Rick Riordan";
        //    //libro.FechaLanzamiento = 2008-05-06;
        //    libro.IdAutor = libroInicial.IdAutor;
        //    libro.IdCategoria = libroInicial.IdCategoria;
        //    libro.IdEditorial = libroInicial.IdEditorial;
        //    libro.Idioma = "Español";
        //    libro.Paginas = 248;
        //    libro.Descripcion = "Percy Jackson, que tiene quince años al final del libro, trata de detener a Luke Castellan y su ejército de invasores de llegar al Campamento Mestizo a través del laberinto de Dédalo, tratando de encontrar a Dédalo y convencerlo de no darle el hilo de Ariadna a Luke, que ayudaría a Luke a atravesar el laberinto.";
        //    libro.ImagenPortada = "https://mega.nz/file/wfIASIKZ#Jgq5JJQcESfe8zskRlynsb8HeeNvgHxXehYIATzajU4";
        //    libro.LinkDescarga = "https://mega.nz/file/lDh32baB#BfP7xbRubeAzJvLVqJ-wvpieffypoUjGxYXfm0xr55w";
        //    libro.ImagenIntroduccion = "https://mega.nz/file/seh2xRIK#oLKvKl5UB3whCb0wcxl7ibfulmAlbXyUIYnNjsAr5Jk";
        //    libro.top_aux = 10;
        //    var resultLibros = await LibroDAL.BuscarIncluirEditorialAsync(libro);
        //    Assert.AreNotEqual(0, resultLibros.Count);
        //    var ultimoLibro = resultLibros.FirstOrDefault();
        //    Assert.IsTrue(ultimoLibro.Editorial != null && libro.IdEditorial == ultimoLibro.Editorial.Id);
        //}

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var libro = new Libro();
            libro.Id = libroInicial.Id;
            int result = await LibroDAL.EliminarAsync(libro);
            Assert.AreNotEqual(0, result);
        }

    }
}