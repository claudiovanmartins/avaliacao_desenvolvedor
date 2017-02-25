using Avaliacao.WorkinHub.Web.Controllers.Base;
using Avaliacao.WorkinHub.Web.DAL.Repository;
using Avaliacao.WorkinHub.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Avaliacao.WorkinHub.Web.Controllers
{
    public class UploadController : BaseController
    {
        public UploadController()
        {
            PedidoRepository = new PedidoRepository();
        }

        [AcceptVerbs("GET")]
        public IEnumerable<Pedido> GetPedidos()
        {
            return PedidoRepository.GetAll().AsEnumerable();
        }

        [AcceptVerbs("GET")]
        public ActionResult Index()
        {
            return View("Index");
        }

        [AcceptVerbs("POST")]
        public PartialViewResult Index(HttpPostedFileBase file)
        {
            List<Pedido> pedidos = new List<Pedido>();
            if (file != null && file.ContentLength > 0)
            {
                
                try
                {
                    string path = Helpers.FileHelper.CombinePath(FOLDER_PATH, file.FileName);
                    file.SaveAs(path);

                    ViewBag.Message = "Arquivo carregado com sucesso";

                    if (Helpers.FileHelper.IsValidFile(path))
                    {
                        var lines = Helpers.FileHelper.ReadFile(path);

                        pedidos = SaveData(lines);
                    }
                    else
                    {
                        throw new Exception("Arquivo Inválido!");
                    }
                    
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERRO:" + ex.Message.ToString();
                    return PartialView();
                }
            }
            else
            {
                ViewBag.Message = "Nenhum arquivo foi selecionado.";
                return PartialView();
            }

            return PartialView(pedidos);
        }

        private List<Pedido> SaveData(IEnumerable<string> lines)
        {
            List<Pedido> pedidos = new List<Pedido>();

            for (int i = 1; i < lines.Count(); i++)
            {
                var item = lines.ElementAt(i).Split('\t');
                Pedido pedido = new Pedido
                {
                    Cliente = item[0].ToString(),
                    Descricao = item[1].ToString(),
                    PrecoUnitario = decimal.Parse(item[2].ToString().Replace(".", ",")),
                    Quantidade = int.Parse(item[3].ToString()),
                    Endereco = item[4].ToString(),
                    Fornecedor = item[5].ToString()
                };
                PedidoRepository.Add(pedido);
                PedidoRepository.SaveAll();
                pedidos.Add(pedido);
            }

            return pedidos;
        }
    }
}

