using LiteraryWings.AccesoADatos;
using LiteraryWings.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraryWings.LogicaDeNegocio
{
    public class AutorBL
    {
        public async Task<int> CrearAsync(Autor pAtor)
        {
            return await AutorDAL.CrearAsync(pAtor);
        }

        public async Task<int> ModificarAsync(Autor pAtor)
        {
            return await AutorDAL.ModificarAsync(pAtor);
        }

        public async Task<int> EliminarAsync(Autor pAtor)
        {
            return await AutorDAL.EliminarAsync(pAtor);
        }

        public async Task<Autor> ObtenerPorIdAsync(Autor pAtor)
        {
            return await AutorDAL.ObtenerPorIdAsync(pAtor);
        }

        public async Task<List<Autor>> ObtenerTodosAsync()
        {
            return await AutorDAL.ObtenerTodosAsync();
        }

        public async Task<List<Autor>> BuscarAsync(Autor pAtor)
        {
            return await AutorDAL.BuscarAsync(pAtor);
        }
    }
}
