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
    public class UsuarioDALTests
    {
        private static Usuario usuarioInicial = new Usuario { id = 2, IdRol = 1, Login = "JuanUser", Password = "12345" };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var usuario = new Usuario();
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "juan";
            usuario.Apellido = "lopez";
            usuario.Login = "juanUser";
            string password = "12345";
            usuario.Password = password;
            usuario.Estatus = (byte)Estatus_Usuario.INACTIVO;
            int result = await UsuarioDAL.CrearAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.id = usuario.id;
            usuarioInicial.Password = password;
            usuarioInicial.Login = usuario.Login;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var usuario = new Usuario();
            usuario.id = usuarioInicial.id;
            usuario.IdRol = usuarioInicial.IdRol;
            usuario.Nombre = "Juan";
            usuario.Apellido = "Lopez";
            usuario.Login = "JuanUser01";
            usuario.Estatus = (byte)Estatus_Usuario.ACTIVO;
            int result = await UsuarioDAL.ModificarAsync(usuario);
            Assert.AreNotEqual(0, result);
            usuarioInicial.Login = usuario.Login;
        }

        [TestMethod()]
        public async Task T3EliminarAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T4ObtenerPorIdAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T5ObtenerTodosAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T6BuscarAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T7BuscarIncluirRolesAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T8LoginAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T9CambiarPasswordAsyncTest()
        {
            Assert.Fail();
        }
    }
}