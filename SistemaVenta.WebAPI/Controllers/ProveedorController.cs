using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.EntidadesDeNegocio;
using SistemaVenta.LogicaDeNegocio;
using System.Text.Json;

namespace SistemaVenta.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private ProveedorBL proveedorBL = new ProveedorBL();

        [HttpGet]
        public async Task<IEnumerable<Proveedor>> Get()
        {
            return await proveedorBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Proveedor> Get(int id)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Id = id;
            return await proveedorBL.ObtenerPorIdAsync(proveedor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Proveedor proveedor)
        {
            try
            {
                await proveedorBL.CrearAsync(proveedor);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Proveedor proveedor)
        {

            if (proveedor.Id == id)
            {
                await proveedorBL.ModificarAsync(proveedor);
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
                Proveedor proveedor = new Proveedor();
                proveedor.Id = id;
                await proveedorBL.EliminarAsync(proveedor);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Proveedor>> Buscar([FromBody] object pProveedor)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProveedor = JsonSerializer.Serialize(pProveedor);
            Proveedor proveedor = JsonSerializer.Deserialize<Proveedor>(strProveedor, option);
            return await proveedorBL.BuscarAsync(proveedor);

        }
    }
}
