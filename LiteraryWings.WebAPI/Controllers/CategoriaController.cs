﻿using LiteraryWings.EntidadesDeNegocio;
using LiteraryWings.LogicaDeNegocio;
using LiteraryWings.WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LiteraryWings.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaBL categoriaBL = new CategoriaBL();

        [HttpGet]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await categoriaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Categoria> Get(int id)
        {
            Categoria categoria = new Categoria();
            categoria.id = id;
            return await categoriaBL.ObtenerPorIdAsync(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                await categoriaBL.CrearAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
        {

            if (categoria.id == id)
            {
                await categoriaBL.ModificarAsync(categoria);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.id = id;
                await categoriaBL.EliminarAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Categoria>> Buscar([FromBody] object pCategoria)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCategoria = JsonSerializer.Serialize(pCategoria);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);
            return await categoriaBL.BuscarAsync(categoria);

        }
    }
}
