using LiteraryWings.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraryWings.AccesoADatos
{
    public class LibroDAL
    {
        public static async Task<int> CrearAsync(Libro pLibro)
        {
            int result = 0;
            using (var bdcontexto = new DBContexto())
            {
                bdcontexto.Add(pLibro);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Libro pLibro)
        {
            int result = 0;
            using (var bdcontexto = new DBContexto())
            {
                var libro = await bdcontexto.Libro.FirstOrDefaultAsync(l => l.Id == pLibro.Id);
                libro.Nombre = pLibro.Nombre;
                libro.FechaLanzamiento = pLibro.FechaLanzamiento;
                libro.IdAutor = pLibro.IdAutor;
                libro.IdCategoria = pLibro.IdCategoria;
                libro.IdEditorial = pLibro.IdEditorial;
                libro.Idioma = pLibro.Idioma;
                libro.Paginas = pLibro.Paginas;
                libro.Descripcion = pLibro.Descripcion;
                libro.Descripcion2 = pLibro.Descripcion2;
                libro.ImagenPortada = pLibro.ImagenPortada;
                libro.LinkDescarga = pLibro.LinkDescarga;
                libro.ImagenIntroduccion = pLibro.ImagenIntroduccion;
                bdcontexto.Update(libro);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Libro pLibro)
        {
            int result = 0;
            using (var bdcontexto = new DBContexto())
            {
                var libro = await bdcontexto.Libro.FirstOrDefaultAsync(l => l.Id == pLibro.Id);
                bdcontexto.Remove(libro);
                result = await bdcontexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Libro> ObtenerPorIdAsync(Libro pLibro)
        {
            var libro = new Libro();
            using (var bdcontexto = new DBContexto())
            {
                libro = await bdcontexto.Libro.Include(l => l.Autor).Include(l => l.Categoria).Include(l => l.Editorial).FirstOrDefaultAsync(l => l.Id == pLibro.Id);
            }
            return libro;
        }

        public static async Task<List<Libro>> ObtenerTodosAsync()
        {
            var libros = new List<Libro>();
            using (var bdcontexto = new DBContexto())
            {
                libros = await bdcontexto.Libro.ToListAsync();
            }
            return libros;
        }

        internal static IQueryable<Libro> QuerySelect(IQueryable<Libro> pQuery, Libro pLibro)
        {
            if (pLibro.Id > 0)
                pQuery = pQuery.Where(l => l.Id == pLibro.Id);

            if (pLibro.IdAutor > 0)
                pQuery = pQuery.Where(l => l.IdAutor == pLibro.IdAutor);

            if (pLibro.IdCategoria > 0)
                pQuery = pQuery.Where(l => l.IdCategoria == pLibro.IdCategoria);

            if (pLibro.IdEditorial > 0)
                pQuery = pQuery.Where(l => l.IdEditorial == pLibro.IdEditorial);

            if (!string.IsNullOrWhiteSpace(pLibro.Nombre))
                pQuery = pQuery.Where(l => l.Nombre.Contains(pLibro.Nombre));

            if (!string.IsNullOrWhiteSpace(pLibro.FechaLanzamiento))
                pQuery = pQuery.Where(l => l.FechaLanzamiento.Contains(pLibro.FechaLanzamiento));

            if (!string.IsNullOrWhiteSpace(pLibro.Idioma))
                pQuery = pQuery.Where(l => l.Idioma.Contains(pLibro.Idioma));

            if (!string.IsNullOrWhiteSpace(pLibro.Descripcion))
                pQuery = pQuery.Where(l => l.Descripcion.Contains(pLibro.Descripcion));

            if (!string.IsNullOrWhiteSpace(pLibro.Descripcion2))
                pQuery = pQuery.Where(l => l.Descripcion2.Contains(pLibro.Descripcion2));

            if (pLibro.Paginas > 0)
                pQuery = pQuery.Where(l => l.Paginas == pLibro.Paginas);

            pQuery = pQuery.OrderByDescending(l => l.Id).AsQueryable();
            if (pLibro.top_aux > 0)
                pQuery = pQuery.Take(pLibro.top_aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Libro>> BuscarAsync(Libro pLibro)
        {
            var libros = new List<Libro>();
            using (var bdcontexto = new DBContexto())
            {
                var select = bdcontexto.Libro.AsQueryable();
                select = QuerySelect(select, pLibro);
                libros = await select.ToListAsync();
            }
            return libros;
        }


        public static async Task<List<Libro>> BuscarIncluirLLavesAsync(Libro pLibro)
        {
            var libros = new List<Libro>();
            using (var bdcontexto = new DBContexto())
            {
                var select = bdcontexto.Libro.AsQueryable();
                select = QuerySelect(select, pLibro).Include(l => l.Autor).Include(l=> l.Categoria).Include(l=> l.Editorial).AsQueryable();
                libros = await select.ToListAsync();
            }
            return libros;
        }

        //public static async Task<List<Libro>> BuscarIncluirCategoriaAsync(Libro pLibro)
        //{
        //    var libros = new List<Libro>();
        //    using (var bdcontexto = new DBContexto())
        //    {
        //        var select = bdcontexto.Libro.AsQueryable();
        //        select = QuerySelect(select, pLibro).Include(l => l.Categoria).AsQueryable();
        //        libros = await select.ToListAsync();
        //    }
        //    return libros;
        //}

        //public static async Task<List<Libro>> BuscarIncluirEditorialAsync(Libro pLibro)
        //{
        //    var libros = new List<Libro>();
        //    using (var bdcontexto = new DBContexto())
        //    {
        //        var select = bdcontexto.Libro.AsQueryable();
        //        select = QuerySelect(select, pLibro).Include(l => l.Editorial).AsQueryable();
        //        libros = await select.ToListAsync();
        //    }
        //    return libros;
        //}
    }
}
