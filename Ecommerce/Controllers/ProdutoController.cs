using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DAL;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoDAO pDAO;
        public ProdutoController(ProdutoDAO produtoDAO)
        {
            pDAO = produtoDAO;
        }
        //Todos os metodos que resultarem de uma ação da View são chamados de actions.
        public IActionResult Index()
        { 
            ViewBag.DataHora = DateTime.Now;
            return View(pDAO.ListarProdutos());
        }

        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            
            pDAO.Cadastrar(produto);

            return RedirectToAction("Index");
        }

        public IActionResult Remover(int? id)
        {
            if (id!=null)
            {
                pDAO.ExcluirProduto(id);
            }
            else
            {
                //Direcionar para uma pagina de erro.
            }
            return RedirectToAction("Index");
        }

        public IActionResult Alterar(int? id)
        {
             

            return View(pDAO.BuscarProdutoPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            pDAO.AlterarProduto(produto);
            return RedirectToAction("Index");
        }
    }
}