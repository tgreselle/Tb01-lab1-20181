using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppTb01Lab_Greselle.Models
{
    public class Automovel

    {

        public int AutomovelId { get; set; }

        [Required(ErrorMessage ="Tipo obrigatorio")]
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage ="Descrição é Obrigatorio")]
        [StringLength(300,ErrorMessage = "Maximo 300 caracteres")]
        public string Descricao { get; set; }

        [StringLength(300, ErrorMessage = "Maximo 300 caracteres")]
        [Required(ErrorMessage ="Marca obrigatorio")]
        public string Marca { get; set; }

        [Required(ErrorMessage ="Campos Obrigatorio")]
        public bool Disponivel { get; set; }

        [Required(ErrorMessage ="Preecha a data")]
        public DateTime DataCadastro { get; set; }


    }
}
