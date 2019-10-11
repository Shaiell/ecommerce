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
    }
}
