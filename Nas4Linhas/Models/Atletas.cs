using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nas4Linhas.Models
{
    public class Atletas {

        public Atletas(){

        }

        [Key]
        public int AtletaID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Golos { get; set; }


        [Required]
        public string Nacionalidade { get; set; }

        [Required]
        public DateTime DataNasc { get; set; }

        [Required]
        public int Jogos { get; set; }      
        
        //F. Keys
        public Equipas Equipas { get; set;}
        [ForeignKey("Equipas")]
        public int EquipasFK { get; set; }
    }
}