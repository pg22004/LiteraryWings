using LiteraryWings.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraryWings.AccesoADatos
{
    public class EditorialDAL
    {
        public static async Task<int> CrearAsync(Editorial pEditorial)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pEditorial);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Editorial pEditorial)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var editorial = await dbContexto.Editorial.FirstOrDefaultAsync(s => s.Id == pEditorial.Id);
                editorial.Nombre = pEditorial.Nombre;
                dbContexto.Update(editorial);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Editorial pEditorial)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var editorial = await dbContexto.Editorial.FirstOrDefaultAsync(s => s.Id == pEditorial.Id);
                dbContexto.Editorial.Remove(editorial);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Editorial> ObtenerPorIdAsync(Editorial pEditorial)
        {
            var editorial = new Editorial();
            using (var dbContexto = new DBContexto())
            {
                editorial = await dbContexto.Editorial.FirstOrDefaultAsync(s => s.Id == pEditorial.Id);
            }
            return editorial;
        }

        public static async Task<List<Editorial>> ObtenerTodosAsync()
        {
            var editoriales = new List<Editorial>();
            using (var dbContexto = new DBContexto())
            {
                editoriales = await dbContexto.Editorial.ToListAsync();
            }
            return editoriales;
        }

        internal static IQueryable<Editorial> QuerySelect(IQueryable<Editorial> pQuery, Editorial pEditorial)
        {
            if (pEditorial.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pEditorial.Id);

            if (!string.IsNullOrWhiteSpace(pEditorial.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEditorial.Nombre));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pEditorial.Top_aux > 0)
                pQuery = pQuery.Take(pEditorial.Top_aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Editorial>> BuscarAsync(Editorial pEditorial)
        {
            var editoriales = new List<Editorial>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Editorial.AsQueryable();
                select = QuerySelect(select, pEditorial);
                editoriales = await select.ToListAsync();
            }
            return editoriales;
        }
    }
}

