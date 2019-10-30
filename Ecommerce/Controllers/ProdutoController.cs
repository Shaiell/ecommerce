using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoDAO pDAO;
        private readonly CategoriaDAO cDAO;
        public ProdutoController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO)
        {
            pDAO = produtoDAO;
            cDAO = categoriaDAO;
        }
        //Todos os metodos que resultarem de uma ação da View são chamados de actions.
        public IActionResult Index()
        { 
            ViewBag.DataHora = DateTime.Now;
            return View(pDAO.ListarTodos());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = new SelectList(cDAO.ListarTodos(), "CategoriaId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto, int drpCategorias)
        {
            ViewBag.Categorias = new SelectList(cDAO.ListarTodos(), "CategoriaId", "Nome");
            if (ModelState.IsValid){

                produto.Categoria = cDAO.BuscarPorId(drpCategorias);

                if (pDAO.Cadastrar(produto))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Este produto ja existe");
                    return View(produto);
                }
            }
            return View(produto);
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
             

            return View(pDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            pDAO.AlterarProduto(produto);
            return RedirectToAction("Index");
        }
    }
}