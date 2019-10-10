using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime CriadoEm { get; set; }
        public Produto()
        {
            CriadoEm = DateTime.Now;
        }


    }
}
