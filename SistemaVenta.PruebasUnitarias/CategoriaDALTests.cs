﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class CategoriaDALTests

    {

        private static Categoria categoriaInicial = new Categoria { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Nombre = "Electronicos";
            int result = await CategoriaDAL.CrearAsync(categoria);
            Assert.AreNotEqual(0, result);
            categoriaInicial.Id = categoria.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {

            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            categoria.Nombre = "Electrinic";
            int result = await CategoriaDAL.ModificarAsync(categoria);
            Assert.AreNotEqual(0, result);
        }

        

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            var resultRol = await CategoriaDAL.ObtenerPorIdAsync(categoria);
            Assert.AreEqual(categoria.Id, resultRol.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultCategorias = await CategoriaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCategorias.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Nombre = "e";
            categoria.Top_Aux = 10;
            var resultCategorias = await CategoriaDAL.BuscarAsync(categoria);
            Assert.AreNotEqual(0, resultCategorias.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            int result = await CategoriaDAL.EliminarAsync(categoria);
            Assert.AreNotEqual(0, result);
        }
    }
}