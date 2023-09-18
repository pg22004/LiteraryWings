using LiteraryWings.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraryWings.AccesoADatos
{
    public class AutorDAL
    {
        public static async Task<int> CrearAsync(Autor pAutor)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pAutor);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Autor pAutor)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var autor = await dbContexto.Autor.FirstOrDefaultAsync(a => a.Id == pAutor.Id);
                autor.Nombre = pAutor.Nombre;
                autor.Apellido = pAutor.Apellido;
                autor.FechaNacimiento = pAutor.FechaNacimiento;
                autor.AutorImagen = pAutor.AutorImagen;
                autor.Seudonimo = pAutor.Seudonimo;
                autor.Nacionalidad = pAutor.Nacionalidad;
                dbContexto.Update(autor);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Autor pAutor)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var autor = await dbContexto.Autor.FirstOrDefaultAsync(a => a.Id == pAutor.Id);
                dbContexto.Autor.Remove(autor);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Autor> ObtenerPorIdAsync(Autor pAutor)
        {
            var autor = new Autor();
            using (var dbContexto = new DBContexto())
            {
                autor = await dbContexto.Autor.FirstOrDefaultAsync(a => a.Id == pAutor.Id);
            }
            return autor;
        }

        public static async Task<List<Autor>> ObtenerTodosAsync()
        {
            var autores = new List<Autor>();
            using (var dbContexto = new DBContexto())
            {
                autores = await dbContexto.Autor.ToListAsync();
            }
            return autores;
        }

        internal static IQueryable<Autor> QuerySelect(IQueryable<Autor> pQuery, Autor pAutor)
        {
            if (pAutor.Id > 0)
                pQuery = pQuery.Where(a => a.Id == pAutor.Id);

            if (!string.IsNullOrWhiteSpace(pAutor.Nombre))
                pQuery = pQuery.Where(a => a.Nombre.Contains(pAutor.Nombre));

            if (!string.IsNullOrWhiteSpace(pAutor.Nombre))
                pQuery = pQuery.Where(a => a.Nombre.Contains(pAutor.Nombre));

            if (!string.IsNullOrWhiteSpace(pAutor.FechaNacimiento))
                pQuery = pQuery.Where(a => a.FechaNacimiento.Contains(pAutor.FechaNacimiento));

            if (!string.IsNullOrWhiteSpace(pAutor.Seudonimo))
                pQuery = pQuery.Where(a => a.Seudonimo.Contains(pAutor.Seudonimo));

            if (!string.IsNullOrWhiteSpace(pAutor.Nacionalidad))
                pQuery = pQuery.Where(a => a.Nacionalidad.Contains(pAutor.Nacionalidad));

            if (pAutor.Top_Aux > 0)
                pQuery = pQuery.Take(pAutor.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Autor>> BuscarAsync(Autor pAutor)
        {
            var autores = new List<Autor>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Autor.AsQueryable();
                select = QuerySelect(select, pAutor);
                autores = await select.ToListAsync();
            }
            return autores;
        }
    }
}
