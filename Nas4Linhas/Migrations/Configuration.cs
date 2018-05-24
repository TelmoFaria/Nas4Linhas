namespace Nas4Linhas.Migrations
{
    using Nas4Linhas.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Nas4Linhas.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Nas4Linhas.Models.ApplicationDbContext context)
        {

            var competicao = new List<Competicao> {
                new Competicao {CompeticaoID=1, Nome="Liga Nos", Pais="Portugal"},
                new Competicao {CompeticaoID=2, Nome="Premier League", Pais="Inglaterra"},
                new Competicao {CompeticaoID=3, Nome="Serie A", Pais="Itália"},
                new Competicao {CompeticaoID=4, Nome="Ligue 1", Pais="França"},
                new Competicao {CompeticaoID=5, Nome="Bundesliga", Pais="Alemanha"},
                new Competicao {CompeticaoID=6, Nome="La Liga", Pais="Espanha"}

        };
            competicao.ForEach(cc => context.Competicao.AddOrUpdate(c => c.Nome, cc));
            context.SaveChanges();

            var jogos = new List<Jogos> {
                new Jogos {JogoID=1, EquipaVisitada="Vitoria de Setubal", EquipaVisitante="Tondela", Cartoes=6, Resultado="1-0", DataJogo= new DateTime(2018,05,13), CompeticaoFK=1 },
                new Jogos {JogoID=2, EquipaVisitada="Tottenham", EquipaVisitante="Leicester", Cartoes=3, Resultado="5-4", DataJogo= new DateTime(2018,05,13) ,CompeticaoFK=1},
                new Jogos {JogoID=3, EquipaVisitada="Levante", EquipaVisitante="Barcelona", Cartoes=12, Resultado="5-4", DataJogo= new DateTime(2018,05,13),CompeticaoFK=1},
                new Jogos {JogoID=4, EquipaVisitada="Roma", EquipaVisitante="Juventus", Cartoes=5, Resultado="0-0", DataJogo= new DateTime(2018,05,13),CompeticaoFK=1},
                new Jogos {JogoID=5, EquipaVisitada="FC Schalke 04", EquipaVisitante="Eintracht Frankfurt", Cartoes=2, Resultado="1-0", DataJogo= new DateTime(2018,05,12),CompeticaoFK=1},
                new Jogos {JogoID=6, EquipaVisitada="PSG", EquipaVisitante="Rennes", Cartoes=1, Resultado="0-2", DataJogo= new DateTime(2018,05,12),CompeticaoFK=1}


        };
                jogos.ForEach(jj => context.Jogos.AddOrUpdate(j => j.JogoID,jj));
                context.SaveChanges();

            var equipas = new List<Equipas> {
               new Equipas {EquipaID=13, NomeEquipa="Desportivo das Aves", Classificacao=13, Vitorias=9, Empates=7, Derrotas=18,
                   Logo ="Logo_Desportivo_das_Aves.png", Jogos = new List<Jogos> { jogos[0], jogos[1] } ,CompeticaoFK=1},
               new Equipas {EquipaID=14, NomeEquipa="Moreirense", Classificacao=15, Vitorias=8, Empates=8, Derrotas=18,
                   Logo ="Logo_Moreirense.png",Jogos = new List<Jogos> { jogos[0], jogos[1] },CompeticaoFK=1},
               new Equipas {EquipaID=15, NomeEquipa="Feirense", Classificacao=16, Vitorias=9, Empates=4, Derrotas=21,
                   Logo ="Logo_Feirense.png",Jogos = new List<Jogos> { jogos[0], jogos[1] },CompeticaoFK=1},
               new Equipas {EquipaID=16, NomeEquipa="Paços de Ferreira", Classificacao=17, Vitorias=7, Empates=9, Derrotas=18, Logo="Pacos-de-Ferreira-icon.png",
                   Jogos = new List<Jogos> { jogos[0], jogos[1] },CompeticaoFK=1 },
               new Equipas {EquipaID=17, NomeEquipa="Estoril", Classificacao=18, Vitorias=8, Empates=6, Derrotas=20, Logo="Estoril.png",
               Jogos = new List<Jogos> { jogos[0], jogos[1] },CompeticaoFK=1},
               new Equipas {EquipaID=18, NomeEquipa="Vitória de Setúbal", Classificacao=14, Vitorias=7, Empates=11, Derrotas=16, Logo="Vitoria_Setubal.png",
               Jogos = new List<Jogos> { jogos[0], jogos[1] }, CompeticaoFK=1}



        };
            equipas.ForEach(ee => context.Equipas.AddOrUpdate(e => e.NomeEquipa, ee));
            context.SaveChanges();

        var atletas = new List<Atletas> {
                new Atletas {AtletaID=1, Nome="Costinha", Nacionalidade="Portuguesa", Golos=2, DataNasc= new DateTime(1992,08,25), Jogos=31, EquipasFK=1},
                new Atletas {AtletaID=2, Nome="Halliche", Nacionalidade="Argelina", Golos=2, DataNasc= new DateTime(1986,09,02), Jogos=22, EquipasFK=1},
                new Atletas {AtletaID=3, Nome="Karamanos", Nacionalidade="Grega", Golos=0, DataNasc= new DateTime(1990,09,21), Jogos=12, EquipasFK=1},
                new Atletas {AtletaID=4, Nome="Arsénio", Nacionalidade="Portuguesa", Golos=2, DataNasc= new DateTime(1989,08,30), Jogos=28, EquipasFK=1},
                new Atletas {AtletaID=5, Nome="Bruno Moreira", Nacionalidade="Portuguesa", Golos=4, DataNasc= new DateTime(1987,09,06), Jogos=31,EquipasFK=1},
                new Atletas {AtletaID=6, Nome="Ryan Gauld", Nacionalidade="Escocesa", Golos=1, DataNasc= new DateTime(1995,12,16), Jogos=19,EquipasFK=1}


};
                atletas.ForEach(aa => context.Atletas.AddOrUpdate(a => a.Nome,aa));
                context.SaveChanges();

        }
    }
}
