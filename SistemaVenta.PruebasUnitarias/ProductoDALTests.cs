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
    public class ProductoDALTests
    {
        private static Producto productoInicial = new Producto { Id = 1, IdCategoria = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Codigo = "002";
            producto.Nombre = "Conectores";
            producto.Descripcion = "Conectores de tipo USB";
            producto.Precio = Convert.ToDecimal("2.50");
            int result = await ProductoDAL.CrearAsync(producto);
            Assert.AreNotEqual(0, result);
            productoInicial.Id = producto.Id;

        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Codigo = "003";
            producto.Nombre = "Conector";
            producto.Descripcion = "Conectores de tipo USB";
            producto.Precio = Convert.ToDecimal("2.50");
            int result = await ProductoDAL.CrearAsync(producto);
            Assert.AreNotEqual(0, result);
            productoInicial.Id = producto.Id;


        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            var resultProducto = await ProductoDAL.ObtenerPorIdAsync(producto);
            Assert.AreEqual(producto.Id, resultProducto.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProductos = await ProductoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProductos.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var producto = new Producto();
            producto.Codigo = "00";
            producto.Nombre = "a";
            producto.Descripcion = "e";
            //producto.Precio = Convert.ToDecimal("2.50");
            producto.Top_Aux = 10;
            var resultProductos = await ProductoDAL.BuscarAsync(producto);
            Assert.AreNotEqual(0, resultProductos.Count);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            int result = await ProductoDAL.EliminarAsync(producto);
            Assert.AreNotEqual(0, result);
        }


    }

}


