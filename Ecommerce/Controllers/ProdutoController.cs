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

            return View();
        }
    }
}