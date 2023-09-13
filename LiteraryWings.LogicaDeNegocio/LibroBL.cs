using LiteraryWings.AccesoADatos;
using LiteraryWings.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraryWings.LogicaDeNegocio
{
    public class LibroBL
    {

        public async Task<int> CrearAsync(Libro pLibro)
        {
            return await LibroDAL.CrearAsync(pLibro);
        }

        public async Task<int> ModificarAsync(Libro pLibro)
        {
            return await LibroDAL.ModificarAsync(pLibro);
        }

        public async Task<int> EliminarAsync(Libro pLibro)
        {
            return await LibroDAL.EliminarAsync(pLibro);
        }

        public async Task<Libro> ObtenerPorIdAsync(Libro pLibro)
        {
            return await LibroDAL.ObtenerPorIdAsync(pLibro);
        }

        public async Task<List<Libro>> ObtenerTodosAsync()
        {
            return await LibroDAL.ObtenerTodosAsync();
        }

        public async Task<List<Libro>> BuscarAsync(Libro pLibro)
        {
            return await LibroDAL.BuscarAsync(pLibro);
        }

        public async Task<List<Libro>> BuscarIncluirAutorAsync(Libro pLibro)
        {
            return await LibroDAL.BuscarIncluirAutorAsync(pLibro);
        }

        public async Task<List<Libro>> BuscarIncluirCategoriaAsync(Libro pLibro)
        {
            return await LibroDAL.BuscarIncluirCategoriaAsync(pLibro);
        }

        public async Task<List<Libro>> BuscarIncluirEditorialAsync(Libro pLibro)
        {
            return await LibroDAL.BuscarIncluirEditorialAsync(pLibro);
        }
    }
}
