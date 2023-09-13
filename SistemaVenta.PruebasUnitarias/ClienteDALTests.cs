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
    public class ClienteDALTests
    {
        private static Cliente clienteInicial = new Cliente { Id = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Nombre = "Cristina";
            cliente.Apellido = "Rosales";
            cliente.Direccion = "Sonsonate";
            cliente.Correo = "cr@gmail.com";
            cliente.Telefono = "77427582";
            int result = await ClienteDAL.CrearAsync(cliente);
            Assert.AreNotEqual(0, result);
            clienteInicial.Id = cliente.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Nombre = "cristina";
            cliente.Apellido = "rosales";
            cliente.Direccion = "Sonsonate";
            cliente.Correo = "cr@gmail.com";
            cliente.Telefono = "77427582";
            int result = await ClienteDAL.CrearAsync(cliente);
            Assert.AreNotEqual(0, result);
            clienteInicial.Id = cliente.Id;
        }

        

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {

            var cliente = new Cliente();
            cliente.Id = clienteInicial.Id;
            var resultCliente = await ClienteDAL.ObtenerPorIdAsync(cliente);
            Assert.AreEqual(cliente.Id, resultCliente.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultClientes = await ClienteDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultClientes.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Nombre = "A";
            cliente .Apellido = "a";
            cliente.Direccion = "A";
            cliente.Top_Aux = 10;
            var resultClientes = await ClienteDAL.BuscarAsync(cliente);
            Assert.AreNotEqual(2, resultClientes.Count);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var cliente = new Cliente();
            cliente.Id = clienteInicial.Id;
            int result = await ClienteDAL.EliminarAsync(cliente);
            Assert.AreNotEqual(0, result);
        }
    }
}