using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nas4Linhas.Models
{
    public class Equipas
    {
        public Equipas() {

            this.Atletas = new HashSet<Atletas>();
            this.Jogos = new HashSet<Jogos>();
        }

        [Key]
        public int EquipaID { get; set; }

        [Required]
        public string NomeEquipa { get; set; }

        [Required]
        public int Classificacao { get; set; }

        [Required]
        public int Vitorias { get; set; }

        [Required]
        public int Empates { get; set; }

        [Required]
        public int Derrotas { get; set; }

        [Required]
        public string Logo { get; set; }

        //many to many
        public virtual ICollection<Jogos> Jogos { get; set; }
        public virtual ICollection<Atletas> Atletas { get; set; }

        //Foreign Keys
        [ForeignKey("Competicao")]
        public int CompeticaoFK { get; set; }
        public virtual Competicao Competicao { get; set; }

    }
}