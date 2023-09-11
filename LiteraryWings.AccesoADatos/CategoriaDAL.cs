using System;
using LiteraryWings.EntidadesDeNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiteraryWings.AccesoADatos
{
    public class CategoriaDAL
    {
        public static async Task<int> CrearAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pCategoria);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var categoria = await dbContexto.Categoria.FirstOrDefaultAsync(s => s.id == pCategoria.id);
                categoria.Nombre = pCategoria.Nombre;
                dbContexto.Update(categoria);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var categoria = await dbContexto.Categoria.FirstOrDefaultAsync(s => s.id == pCategoria.id);
                dbContexto.Categoria.Remove(categoria);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Categoria> ObtenerPorIdAsync(Categoria pCategoria)
        {
            var categoria = new Categoria();
            using (var dbContexto = new DBContexto())
            {
                categoria = await dbContexto.Categoria.FirstOrDefaultAsync(s => s.id == pCategoria.id);
            }
            return categoria;
        }

        public static async Task<List<Categoria>> ObtenerTodosAsync()
        {
            var categorias = new List<Categoria>();
            using (var dbContexto = new DBContexto())
            {
                categorias = await dbContexto.Categoria.ToListAsync();
            }
            return categorias;
        }

        internal static IQueryable<Categoria> QuerySelect(IQueryable<Categoria> pQuery, Categoria pCategoria)
        {
            if (pCategoria.id > 0)
                pQuery = pQuery.Where(s => s.id == pCategoria.id);
            if (!String.IsNullOrWhiteSpace(pCategoria.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pCategoria.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.id).AsQueryable();
            if (pCategoria.Top_Aux > 0)
                pQuery = pQuery.Take(pCategoria.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            var categorias = new List<Categoria>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Categoria.AsQueryable();
                select = QuerySelect(select, pCategoria);
                categorias = await select.ToListAsync();
            }
            return categorias;
        }
    }
}
