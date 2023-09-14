using Microsoft.EntityFrameworkCore;
using SistemaVenta.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.AccesoADatos
{
    public class ProveedorDAL
    {


        public static async Task<int> CrearAsync(Proveedor pProveedor)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                pProveedor.FechaRegistro = DateTime.Now;
                bdContexto.Add(pProveedor);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Proveedor pProveedor)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var proveedor = await bdContexto.Proveedor.FirstOrDefaultAsync(s => s.Id == pProveedor.Id);
                proveedor.Nombre = pProveedor.Nombre;
                proveedor.Correo = pProveedor.Correo;
                proveedor.Telefono = pProveedor.Telefono;
                bdContexto.Update(proveedor);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Proveedor pProveedor)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var proveedor = await bdContexto.Proveedor.FirstOrDefaultAsync(s => s.Id == pProveedor.Id);
                bdContexto.Proveedor.Remove(proveedor);
                result = await bdContexto.SaveChangesAsync();

            }
            return result;
        }
        public static async Task<Proveedor> ObtenerPorIdAsync(Proveedor pProveedor)
        {
            var proveedor = new Proveedor();
            using (var bdContexto = new BDContexto())
            {
                proveedor = await bdContexto.Proveedor.FirstOrDefaultAsync(s => s.Id == pProveedor.Id);
            }
            return proveedor;
        }

        public static async Task<List<Proveedor>> ObtenerTodosAsync()
        {
            var proveedores = new List<Proveedor>();
            using (var bdContexto = new BDContexto())
            {
                proveedores = await bdContexto.Proveedor.ToListAsync();
            }
            return proveedores;
        }
        internal static IQueryable<Proveedor> QuerySelect(IQueryable<Proveedor> pQuery, Proveedor pProveedor)
        {
            if (pProveedor.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pProveedor.Id);
            if (!string.IsNullOrWhiteSpace(pProveedor.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pProveedor.Nombre));
            if (!string.IsNullOrWhiteSpace(pProveedor.Correo))
                pQuery = pQuery.Where(s => s.Correo.Contains(pProveedor.Correo));
            if (!string.IsNullOrWhiteSpace(pProveedor.Telefono))
                pQuery = pQuery.Where(s => s.Telefono.Contains(pProveedor.Telefono));
            if (pProveedor.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pProveedor.FechaRegistro.Year, pProveedor.FechaRegistro.Month, pProveedor.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pProveedor.Top_Aux > 0)
                pQuery = pQuery.Take(pProveedor.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Proveedor>> BuscarAsync(Proveedor pProveedor)
        {
            var proveedores = new List<Proveedor>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Proveedor.AsQueryable();
                select = QuerySelect(select, pProveedor);
                proveedores = await select.ToListAsync();
            }
            return proveedores;
        }

        

    }
}