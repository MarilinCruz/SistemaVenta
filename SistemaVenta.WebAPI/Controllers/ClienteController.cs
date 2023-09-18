using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.EntidadesDeNegocio;
using SistemaVenta.LogicaDeNegocio;
using System.Text.Json;

namespace SistemaVenta.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteBL clienteBL = new ClienteBL();

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await clienteBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Cliente> Get(int id)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            return await clienteBL.ObtenerPorIdAsync(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                await clienteBL.CrearAsync(cliente);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente cliente)
        {

            if (cliente.Id == id)
            {
                await clienteBL.ModificarAsync(cliente);
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
                Cliente cliente = new Cliente();
                cliente.Id = id;
                await clienteBL.EliminarAsync(cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Cliente>> Buscar([FromBody] object pCliente)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCliente = JsonSerializer.Serialize(pCliente);
            Cliente cliente = JsonSerializer.Deserialize<Cliente>(strCliente, option);
            return await clienteBL.BuscarAsync(cliente);

        }
    }
}
