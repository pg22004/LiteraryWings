using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteraryWings.AccesoADatos;
using LiteraryWings.EntidadesDeNegocio;

namespace LiteraryWings.LogicaDeNegocio
{
    public class SugerenciaBL
    {
        public async Task<int> CrearAsync(Sugerencia pSugerencia)
        {
            return await SugerenciaDAL.CrearAsync(pSugerencia);
        }

        public async Task<int> ModificarAsync(Sugerencia pSugerencia)
        {
            return await SugerenciaDAL.ModificarAsync(pSugerencia);
        }

        public async Task<int> EliminarAsync(Sugerencia pSugerencia)
        {
            return await SugerenciaDAL.EliminarAsync(pSugerencia);
        }

        public async Task<Sugerencia> ObtenerPorIdAsync(Sugerencia pSugerencia)
        {
            return await SugerenciaDAL.ObtenerPorIdAsync(pSugerencia);
        }

        public async Task<List<Sugerencia>> ObtenerTodosAsync()
        {
            return await SugerenciaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Sugerencia>> BuscarAsync(Sugerencia pSugerencia)
        {
            return await SugerenciaDAL.BuscarAsync(pSugerencia);
        }
    }
}
