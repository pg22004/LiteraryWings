using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiteraryWings.AccesoADatos;
using LiteraryWings.EntidadesDeNegocio;

namespace LiteraryWings.LogicaDeNegocio
{
   
        public class EditorialBL
        {
            public async Task<int> CrearAsync(Editorial pEditorial)
            {
                return await EditorialDAL.CrearAsync(pEditorial);
            }

            public async Task<int> ModificarAsync(Editorial pEditorial)
            {
                return await EditorialDAL.ModificarAsync(pEditorial);
            }

            public async Task<int> EliminarAsync(Editorial pEditorial)
            {
                return await EditorialDAL.EliminarAsync(pEditorial);
            }

            public async Task<Editorial> ObtenerPorIdAsync(Editorial pEditorial)
            {
                return await EditorialDAL.ObtenerPorIdAsync(pEditorial);
            }

            public async Task<List<Editorial>> ObtenerTodosAsync()
            {
                return await EditorialDAL.ObtenerTodosAsync();
            }

            public async Task<List<Editorial>> BuscarAsync(Editorial pEditorial)
            {
                return await EditorialDAL.BuscarAsync(pEditorial);
            }
        }
    }

