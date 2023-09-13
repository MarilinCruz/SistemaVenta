using Microsoft.EntityFrameworkCore;
using SistemaVenta.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.AccesoADatos
{
    public class VentaDAL
    {
        public static async Task<int> CrearAsync(Venta pVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pVenta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Venta pVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var venta = await bdContexto.Venta.FirstOrDefaultAsync(s => s.Id == pVenta.Id);
                venta.IdUsuario = pVenta.IdUsuario;
                venta.IdProducto = pVenta.IdProducto;
                venta.NombreCliente = pVenta.NombreCliente;
                venta.ApellidoCliente = pVenta.ApellidoCliente;
                venta.MontoPago = pVenta.MontoPago;
                venta.MontoCambio = pVenta.MontoCambio;
                venta.MontoTotal= pVenta.MontoTotal;
                bdContexto.Update(pVenta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Venta pVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var venta = await bdContexto.Venta.FirstOrDefaultAsync(s => s.Id == pVenta.Id);
                bdContexto.Venta.Remove(venta);
                result = await bdContexto.SaveChangesAsync();

            }
            return result;
        }
        public static async Task<Venta> ObtenerPorIdAsync(Venta pVenta)
        {
            var venta = new Venta();
            using (var bdContexto = new BDContexto())
            {
                venta = await bdContexto.Venta.FirstOrDefaultAsync(s => s.Id == pVenta.Id);
            }
            return venta;
        }

        public static async Task<List<Venta>> ObtenerTodosAsync()
        {
            var ventas = new List<Venta>();
            using (var bdContexto = new BDContexto())
            {
                ventas = await bdContexto.Venta.ToListAsync();
            }
            return ventas;
        }
        internal static IQueryable<Venta> QuerySelect(IQueryable<Venta> pQuery, Venta pVenta)
        {
            if (pVenta.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pVenta.Id);
            if (pVenta.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pVenta.Id);
            if (pVenta.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pVenta.Id);
            if (!string.IsNullOrWhiteSpace(pVenta.NombreCliente))
                pQuery = pQuery.Where(s => s.NombreCliente.Contains(pVenta.NombreCliente));
            if (!string.IsNullOrWhiteSpace(pVenta.ApellidoCliente))
                pQuery = pQuery.Where(s => s.ApellidoCliente.Contains(pVenta.ApellidoCliente));
            if (pVenta.MontoPago > 0)
                pQuery = pQuery.Where(s => s.MontoPago == pVenta.MontoPago);
            if (pVenta.MontoCambio > 0)
                pQuery = pQuery.Where(s => s.MontoCambio == pVenta.MontoCambio);
            if (pVenta.MontoTotal > 0)
                pQuery = pQuery.Where(s => s.MontoTotal == pVenta.MontoTotal);

            if (pVenta.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pVenta.FechaRegistro.Year, pVenta.FechaRegistro.Month, pVenta.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pVenta.Top_Aux > 0)
                pQuery = pQuery.Take(pVenta.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Venta>> BuscarAsync(Venta pVenta)
        {
            var ventas = new List<Venta>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Venta.AsQueryable();
                select = QuerySelect(select, pVenta);
                ventas = await select.ToListAsync();
            }
            return ventas;
        }

        public static async Task<List<Venta>> BuscarIncluirRolAsync(Venta pVenta)
        {
            var ventas = new List<Venta>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Venta.AsQueryable();
                select = QuerySelect(select, pVenta);
                ventas = await select.ToListAsync();
            }
            return ventas;
        }

    }
}
