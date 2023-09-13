﻿using LiteraryWings.EntidadesDeNegocio;
using LiteraryWings.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteraryWings.LogicaDeNegocio
{
    public class CategoriaBL
    {
        public async Task<int> CrearAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.CrearAsync(pCategoria);
        }

        public async Task<int> ModificarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.ModificarAsync(pCategoria);
        }

        public async Task<int> EliminarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.EliminarAsync(pCategoria);
        }

        public async Task<Categoria> ObtenerPorIdAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.ObtenerPorIdAsync(pCategoria);
        }

        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            return await CategoriaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.BuscarAsync(pCategoria);
        }
    }
}
