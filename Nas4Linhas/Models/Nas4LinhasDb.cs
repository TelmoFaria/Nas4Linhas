using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Nas4Linhas.Models
{
    public class Nas4LinhasDb : DbContext {

        public Nas4LinhasDb() : base("Nas4LinhasDbConnectionString") { }

        //descrever o nome das tabelas na base de dados
        public virtual DbSet<Atletas> Atletas { get; set; } //tabela atletas
        public virtual DbSet<Competicao> Competicao { get; set; } //tabela competicao
        public virtual DbSet<Equipas> Equipas { get; set; } //tabela equipas
        public virtual DbSet<Jogos> Jogos { get; set; } //tabela jogos

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}