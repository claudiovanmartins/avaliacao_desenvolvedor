using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Avaliacao.WorkinHub.Web.DAL.Repository;
using System.Linq;
using Avaliacao.WorkinHub.Web.Models;
using System.Collections.Generic;

namespace Avaliacao.WorkinHub.Web.Tests.Models
{
    [TestClass]
    public class PedidoRepositoryTest
    {
        private PedidoRepository _repo;

        [TestInitialize]
        public void TestInitialize()
        {
            _repo = new PedidoRepository();
        }

        [TestMethod]
        public void GetAllPedidos()
        {
            var pedidos = _repo.GetAll().ToList();

            Assert.IsNotNull(pedidos);
        }

        [TestMethod]
        public void GetPedidosByID()
        {
            var pedido = _repo.Get(x => x.PedidoID.Equals(1));

            Assert.IsNotNull(pedido);
        }

        [TestMethod]
        public void SavePedidos()
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>()
            {
                new Pedido { PedidoID = 1, Cliente = "João Silva", Descricao = "R$10 off R$20 of food", PrecoUnitario = Convert.ToDecimal("10.0".ToString().Replace(".",",")), Quantidade = 2, Endereco = "987 Fake St", Fornecedor = "Bob's Pizza" },
                new Pedido { PedidoID = 2, Cliente = "Amy Pond",Descricao = "R$30 of awesome for R$10", PrecoUnitario = Convert.ToDecimal("10.0".ToString().Replace(".",",")), Quantidade= 5 ,Endereco = "456 Unreal Rd",Fornecedor = "Tom's Awesome Shop" },
                new Pedido { PedidoID = 3, Cliente = "Marty McFly",Descricao = "R$20 Sneakers for R$5", PrecoUnitario = Convert.ToDecimal("5.0".ToString().Replace(".",",")),  Quantidade=1, Endereco = "123 Fake St",Fornecedor = "Sneaker Store Emporium" },
                new Pedido { PedidoID = 4, Cliente = "Snake Plissken",Descricao = "R$20 Sneakers for R$5", PrecoUnitario = Convert.ToDecimal("5.0".ToString().Replace(".",",")), Quantidade= 4,Endereco = "123 Fake St",Fornecedor = "Sneaker Store Emporium" }
            };

                foreach (var item in pedidos)
                {
                    _repo.Add(item);
                    _repo.SaveAll();
                }

                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.Message);
            }
           

        }
    }
}
