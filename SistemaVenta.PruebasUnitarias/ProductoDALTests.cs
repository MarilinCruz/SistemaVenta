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
        private static Producto productoInicial = new Producto {  Id = 1, IdCategoria = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var producto = new Producto();
            producto.IdCategoria = productoInicial.IdCategoria;
            producto.Codigo = "002";
            producto.Nombre = "Conectores";
            producto.Descripcion = "Conectores de tipo USB";
            producto.Precio = Convert.ToDecimal ("2.50");
            int result = await ProductoDAL.CrearAsync(producto);
            Assert.AreNotEqual(0, result);
            productoInicial.Id = producto.Id;
            
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
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
        public async Task T3ObtenerPorIdAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T6BuscarIncluirRolAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            Assert.Fail();
        }


    }

}

    
