using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class ProdutoDAO
    {
        private readonly Context ctx;
        public ProdutoDAO(Context context)
        {
            ctx = context;
        }

        public void Cadastrar(Produto p)
        {
            ctx.Produtos.Add(p);
            ctx.SaveChanges();
        }

        public List<Produto> ListarProdutos()
        {
            return ctx.Produtos.ToList();
        }

        public Produto BuscarProdutoPorId(int? id) {
            return ctx.Produtos.Find(id);
        }

        public void ExcluirProduto(int? id)
        {
            ctx.Remove(BuscarProdutoPorId(id));
            ctx.SaveChanges();
        }

        
    }
}
