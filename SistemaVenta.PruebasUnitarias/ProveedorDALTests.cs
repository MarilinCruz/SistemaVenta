using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaVenta.AccesoADatos;
using SistemaVenta.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.AccesoADatos.Tests
{
    [TestClass()]
    public class ProveedorDALTests
    {
        private static Proveedor proveedorInicial = new Proveedor { Id = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var proveedor = new Proveedor();
            proveedor.Nombre = "Rodrigo";
            proveedor.Correo = "rodrigo@gmail.com";
            proveedor.Telefono = "75689614";
            int result = await ProveedorDAL.CrearAsync(proveedor);
            Assert.AreNotEqual(0, result);
            proveedorInicial.Id = proveedor.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var proveedor = new Proveedor();
            proveedor.Nombre = "Rodrigo";
            proveedor.Correo = "rodrigo@gmail.com";
            proveedor.Telefono = "75689614";
            int result = await ProveedorDAL.CrearAsync(proveedor);
            Assert.AreNotEqual(0, result);
            proveedorInicial.Id = proveedor.Id;
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var proveedor = new Proveedor();
            proveedor.Id = proveedorInicial.Id;
            var resultProveedor = await ProveedorDAL.ObtenerPorIdAsync(proveedor);
            Assert.AreEqual(proveedor.Id, resultProveedor.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProveedor = await ProveedorDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProveedor.Count);
        }

        [TestMethod()]
        public  async Task T5BuscarAsyncTest()
        {
            var proveedor = new Proveedor();
            proveedor.Nombre = "a";
            proveedor.Correo = "x";
            proveedor.Telefono = "7";
            proveedor.Top_Aux = 10;
            var resultProveedor = await ProveedorDAL.BuscarAsync(proveedor);
            Assert.AreNotEqual(2, resultProveedor.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var proveedor = new Proveedor();
            proveedor.Id = proveedorInicial.Id;
            int result = await ProveedorDAL.EliminarAsync(proveedor);
            Assert.AreNotEqual(0, result);
        }
    }
}