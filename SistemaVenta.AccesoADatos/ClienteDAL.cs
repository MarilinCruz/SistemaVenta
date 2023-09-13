using Microsoft.EntityFrameworkCore;
using SistemaVenta.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.AccesoADatos
{
    public class ClienteDAL
    {
        public static async Task<int> CrearAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                pCliente.FechaRegistro = DateTime.Now;
                bdContexto.Add(pCliente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.Id == pCliente.Id);
                cliente.Nombre = pCliente.Nombre;
                cliente.Apellido = pCliente.Apellido;
                cliente.Direccion = pCliente.Direccion;
                cliente.Correo = pCliente.Correo;
                cliente.Telefono = pCliente.Telefono;
                bdContexto.Update(pCliente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.Id == pCliente.Id);
                bdContexto.Cliente.Remove(cliente);
                result = await bdContexto.SaveChangesAsync();

            }
            return result;
        }
        public static async Task<Cliente> ObtenerPorIdAsync(Cliente pCliente)
        {
            var cliente = new Cliente();
            using (var bdContexto = new BDContexto())
            {
                cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.Id == pCliente.Id);
            }
            return cliente;
        }

        public static async Task<List<Cliente>> ObtenerTodosAsync()
        {
            var clientes = new List<Cliente  >();
            using (var bdContexto = new BDContexto())
            {
                clientes = await bdContexto.Cliente  .ToListAsync();
            }
            return clientes;
        }
        internal static IQueryable<Cliente> QuerySelect(IQueryable<Cliente> pQuery, Cliente pCliente)
        {
            if (pCliente.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pCliente.Id);
            if (!string.IsNullOrWhiteSpace(pCliente.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pCliente.Nombre));
            if (!string.IsNullOrWhiteSpace(pCliente.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pCliente.Apellido));
            if (!string.IsNullOrWhiteSpace(pCliente.Direccion))
                pQuery = pQuery.Where(s => s.Direccion.Contains(pCliente.Direccion));
            if (!string.IsNullOrWhiteSpace(pCliente.Correo))
                pQuery = pQuery.Where(s => s.Correo.Contains(pCliente.Correo));
            if (!string.IsNullOrWhiteSpace(pCliente.Telefono))
                pQuery = pQuery.Where(s => s.Telefono.Contains(pCliente.Telefono));
            if (pCliente.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pCliente.FechaRegistro.Year, pCliente.FechaRegistro.Month, pCliente.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pCliente.Top_Aux > 0)
                pQuery = pQuery.Take(pCliente.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Cliente>> BuscarAsync(Cliente pCliente)
        {
            var clientes = new List<Cliente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Cliente.AsQueryable();
                select = QuerySelect(select, pCliente);
                clientes = await select.ToListAsync();
            }
            return clientes;
        }

       

    }
}