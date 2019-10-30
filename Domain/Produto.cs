using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Domain

    //Annotations ASP.Net Core
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Display(Name ="Produto:")]
        [Required(ErrorMessage ="*Campo Obrigatorio.")]
        public String Nome { get; set; }

        [Display(Name = "Descrição:")]
        [Required(ErrorMessage = "*Campo Obrigatorio.")]
        [MinLength(5,ErrorMessage ="*No minimo 5 characters.")]
        [MaxLength(50,ErrorMessage ="*No maximo 50 characters.")]
        public String Descricao { get; set; }

        [Display(Name = "Preço:")]
        [Required(ErrorMessage = "*Campo Obrigatorio.")]
        public double? Preco { get; set; }

        [Display(Name = "Quantidade:")]
        [Required(ErrorMessage = "*Campo Obrigatorio.")]
        [Range(1,1000, ErrorMessage ="*Os valores devem estar entre 1 e 1000.")]
        public int? Quantidade { get; set; }

        public DateTime CriadoEm { get; set; }

        public Categoria Categoria { get; set; }
        public Produto()
        {
            CriadoEm = DateTime.Now;
        }


    }
}
