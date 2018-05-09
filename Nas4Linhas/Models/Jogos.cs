using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nas4Linhas.Models
{
    public class Jogos
    {
        public Jogos() {

        }

        [Key]
        public int JogoID { get; set; }

        [Required]
        public string NomeJogo { get; set; }

        [Required]
        public string Substituicoes { get; set; }

        [Required]
        public int Cartoes { get; set; }

        [Required]
        public int Golos { get; set; }

        [Required]
        public DateTime DataJogo { get; set; }

        //many to many
        public ICollection<Equipas> Equipas { get; set; }

        //F Keys
        public Competicao Competicao { get; set; }
        [ForeignKey("Competicao")]
        public int CompeticaoFK { get; set; }

    }
}