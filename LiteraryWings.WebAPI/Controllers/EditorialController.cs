using LiteraryWings.EntidadesDeNegocio;
using LiteraryWings.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LiteraryWings.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private EditorialBL editorialBL = new EditorialBL();

        [HttpGet]
        public async Task<IEnumerable<Editorial>> Get()
        {
            return await editorialBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Editorial> Get(int Id)
        {
            Editorial editorial = new Editorial();
            editorial.Id = Id;
            return await editorialBL.ObtenerPorIdAsync(editorial);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Editorial editorial)
        {
            try
            {
                await editorialBL.CrearAsync(editorial);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Editorial editorial)
        {
            if (editorial.Id == id)
            {
                await editorialBL.ModificarAsync(editorial);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deelete(int id)
        {
            try
            {
                Editorial editorial = new Editorial();
                editorial.Id = id;
                await editorialBL.EliminarAsync(editorial);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Editorial>> Buscar([FromBody] object pEditorial)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strEditorial = JsonSerializer.Serialize(pEditorial);
            Editorial editorial = JsonSerializer.Deserialize<Editorial>(strEditorial, option);
            return await editorialBL.BuscarAsync(editorial);

        }
    }
}
