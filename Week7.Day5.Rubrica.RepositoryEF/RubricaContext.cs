using Microsoft.EntityFrameworkCore;
using System;
using Week7.Day5.Rubrica.Core.Entities;

namespace Week7.Day5.Rubrica.RepositoryEF
{
    public class RubricaContext:DbContext
    {
        //Elenco i DbSet ovvero le tabelle/entità
        public DbSet<Contatto> Contatti { get; set; }
        public DbSet<Indirizzo> Indirizzi { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		    Database=CorsiMaster;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Contatto>(new ContattoConfiguration());
            modelBuilder.ApplyConfiguration<Indirizzo>(new IndirizzoConfiguration());
            
        }
    }
}
