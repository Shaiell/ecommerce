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
            ViewBag.Produtos = pDAO.ListarProdutos();
            ViewBag.DataHora = DateTime.Now;
            return View();
        }

        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string txtNome, string txtDescricao, string txtPreco, string txtQuantidade)
        {
            Produto p = new Produto();
            p.Nome = txtNome;
            p.Descricao = txtDescricao;
            p.Preco = Convert.ToDouble(txtPreco);
            p.Quantidade = Convert.ToInt32(txtQuantidade);
            pDAO.Cadastrar(p);

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
            ViewBag.Produto = pDAO.BuscarProdutoPorId(id);

            return View();
        }

        [HttpPost]
        public IActionResult Alterar(string txtNome, string txtDescricao, string txtPreco, string txtQuantidade, string txtId, string hdnId)
        {
            Produto p = pDAO.BuscarProdutoPorId(Convert.ToInt32(hdnId));
            p.Nome = txtNome;
            p.Descricao = txtDescricao;
            p.Preco = Convert.ToDouble(txtPreco);
            p.Quantidade = Convert.ToInt32(txtQuantidade);
            pDAO.AlterarProduto(p);
            return RedirectToAction("Index");
        }
    }
}