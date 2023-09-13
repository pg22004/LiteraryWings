using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LiteraryWings.EntidadesDeNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraryWings.AccesoADatos
{
    public class SugerenciaDAL
    {
            public static async Task<int> CrearAsync(Sugerencia pSugerencia)
            {
                int result = 0;
                using (var bdContexto = new DBContexto())
                {
                    bdContexto.Add(pSugerencia);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }

            public static async Task<int> ModificarAsync(Sugerencia pSugerencia)
            {
                int result = 0;
                using (var bdContexto = new DBContexto())
                {
                    var sugerencia = await bdContexto.Sugerencia.FirstOrDefaultAsync(s => s.Id == pSugerencia.Id);
                    sugerencia.Nombre = pSugerencia.Nombre;
                    bdContexto.Update(sugerencia);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }

            public static async Task<int> EliminarAsync(Sugerencia pSugerencia)
            {
                int result = 0;
                using (var bdContexto = new DBContexto())
                {
                    var sugerencia = await bdContexto.Sugerencia.FirstOrDefaultAsync(s => s.Id == pSugerencia.Id);
                    bdContexto.Sugerencia.Remove(sugerencia);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }

            public static async Task<Sugerencia> ObtenerPorIdAsync(Sugerencia pSugerencia)
            {
                var sugerencia = new Sugerencia();
                using (var bdContexto = new DBContexto())
                {
                    sugerencia = await bdContexto.Sugerencia.FirstOrDefaultAsync(s => s.Id == pSugerencia.Id);
                }
                return sugerencia;
            }

            public static async Task<List<Sugerencia>> ObtenerTodosAsync()
            {
                var sugerencias = new List<Sugerencia>();
                using (var bdContexto = new DBContexto())
                {
                    sugerencias = await bdContexto.Sugerencia.ToListAsync();
                }
                return sugerencias;
            }

            internal static IQueryable<Sugerencia> QuerySelect(IQueryable<Sugerencia> pQuery, Sugerencia pSugerencia)
            {
                if (pSugerencia.Id > 0)
                    pQuery = pQuery.Where(s => s.Id == pSugerencia.Id);

                if (!string.IsNullOrWhiteSpace(pSugerencia.Nombre))
                    pQuery = pQuery.Where(s => s.Nombre.Contains(pSugerencia.Nombre));

                pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

                if (pSugerencia.Top_Aux > 0)
                    pQuery = pQuery.Take(pSugerencia.Top_Aux).AsQueryable();

                return pQuery;
            }

            public static async Task<List<Sugerencia>> BuscarAsync(Sugerencia pSugerencia)
            {
                var sugerencias = new List<Sugerencia>();
                using (var bdContexto = new DBContexto())
                {
                    var select = bdContexto.Sugerencia.AsQueryable();
                    select = QuerySelect(select, pSugerencia);
                    sugerencias = await select.ToListAsync();
                }
                return sugerencias;
            }
        }
    }







