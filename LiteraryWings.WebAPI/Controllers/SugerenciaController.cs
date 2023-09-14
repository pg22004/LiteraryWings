using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LiteraryWings.EntidadesDeNegocio;
using LiteraryWings.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using LiteraryWings.AccesoADatos;

namespace LiteraryWings.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugerenciaController : ControllerBase
    {
        private SugerenciaBL sugerenciaBL = new SugerenciaBL();

        [HttpGet]
        public async Task<IEnumerable<Sugerencia>> Get()
        {
            return await sugerenciaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Sugerencia> Get(int id)
        {
            Sugerencia sugerencia = new Sugerencia();
            sugerencia.Id = id;
            return await sugerenciaBL.ObtenerPorIdAsync(sugerencia);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Sugerencia sugerencia)
        {
            try
            {
                await sugerenciaBL.CrearAsync(sugerencia);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Sugerencia sugerencia)
        {

            if (sugerencia.Id == id)
            {
                await sugerenciaBL.ModificarAsync(sugerencia);
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
                Sugerencia sugerencia = new Sugerencia();
                sugerencia.Id = id;
                await sugerenciaBL.EliminarAsync(sugerencia);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Sugerencia>> Buscar([FromBody] object pSugerencia)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strSugerencia = JsonSerializer.Serialize(pSugerencia);
            Sugerencia sugerencia = JsonSerializer.Deserialize<Sugerencia>(strSugerencia, option);
            return await sugerenciaBL.BuscarAsync(sugerencia);

        }
    }
}
