using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository;

namespace Ecommerce.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaDAO ctDAO;

        public CategoriaController(CategoriaDAO categoriaDAO)
        {
            ctDAO = categoriaDAO;
        }

        public IActionResult Index()
        {
            return View(ctDAO.ListarTodos());
        }

        

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (ctDAO.Cadastrar(categoria))
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("","Essa Categoria ja existe");
            return View(categoria);
        }

       
    }
}
