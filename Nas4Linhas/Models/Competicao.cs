using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nas4Linhas.Models
{
    public class Competicao
    {
        public Competicao()
        {
            this.Jogos = new HashSet<Jogos>();
            this.Equipas = new HashSet<Equipas>();
        }

        [Key]
        public int CompeticaoID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Pais { get; set; }


        //Relacionar Modelos
        public virtual ICollection<Jogos> Jogos { get; set; }
        public virtual ICollection<Equipas> Equipas { get; set; }

    }
}