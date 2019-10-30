using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CategoriaDAO : IRepository<Categoria>
    {
        private readonly Context ctx;

        public CategoriaDAO(Context context)
        {
            ctx = context;
        }

        public Categoria BuscarPorId(int? id)
        {
            return ctx.Categoria.Find(id);
        }

        public bool Cadastrar(Categoria objeto)
        {
            if(BuscarPorNome(objeto) == null)
            {
                ctx.Categoria.Add(objeto);
                ctx.SaveChanges();
                return true;
            }

            return false;
        }

        public Categoria BuscarPorNome(Categoria categoria)
        {
            return ctx.Categoria.FirstOrDefault(x => x.Nome.Equals(categoria.Nome));
        }

        public List<Categoria> ListarTodos()
        {
            return ctx.Categoria.ToList();
        }
    }
}
