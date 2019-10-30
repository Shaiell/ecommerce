using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ProdutoDAO : IRepository<Produto>
    {
        private readonly Context ctx;
        public ProdutoDAO(Context context)
        {
            ctx = context;
        }

        public bool Cadastrar(Produto p)
        {
            if(BuscarProdutoPorNome(p) == null) { 
                ctx.Produtos.Add(p);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Produto BuscarProdutoPorNome(Produto p)
        {
            return ctx.Produtos.FirstOrDefault(x => x.Nome.Equals(p.Nome));
        }

        public List<Produto> ListarTodos()
        {
            return ctx.Produtos.ToList();
        }

        public Produto BuscarPorId(int? id) {
            return ctx.Produtos.Find(id);
        }

        public void ExcluirProduto(int? id)
        {
            ctx.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public void AlterarProduto(Produto p)
        {
            ctx.Update(p);
            ctx.SaveChanges();
        }
        
    }
}
